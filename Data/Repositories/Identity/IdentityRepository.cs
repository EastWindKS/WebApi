using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Context;
using WebAPI.Models.Authenticate;
using WebAPI.Security.NewUserEmployee;
using WebAPI.Services.Novell;

namespace WebAPI.Data.Repositories.Identity
{
    public class IdentityRepository : IIdentityRepository
    {
        public IdentityRepository()
        {
            _authenticateDbContext = new AuthenticateDbContext(new DbContextOptions<AuthenticateDbContext>());
        }

        private readonly AuthenticateDbContext _authenticateDbContext;

        public async Task CreateNewUser(NovellUser novellUser, UserManager<ApplicationUser> userManager)
        {
            CreateSecurityLoginDb(novellUser.CN);
            var email = novellUser.Attributes.ContainsKey("mail") ? novellUser.Attributes["mail"][0] : string.Empty;
            var user = await CreateIdentityUser(userManager, novellUser.CN, novellUser.Password, email);
            await userManager.AddToRoleAsync(user, "Personnel");
            GrantStandardRightsToPersonnel(novellUser, user.Id);
        }

        private static SqlParameter CreateSqlParameter(string name, object value)
        {
            return new SqlParameter
            {
                ParameterName = $"@{name}",
                IsNullable = false,
                Direction = ParameterDirection.Input,
                DbType = DbType.String,
                Value = value
            };
        }

        private void GrantStandardRightsToPersonnel(NovellUser novellUser, string userId)
        {
            var office = novellUser.Attributes.ContainsKey("ou") ? novellUser.Attributes["ou"][0] : string.Empty;
            var title = novellUser.Attributes.ContainsKey("title") ? novellUser.Attributes["title"][0] : string.Empty;
            var paramUserId = CreateSqlParameter("AspNetUserId", userId);
            var paramOffice = CreateSqlParameter("Office", office);
            var paramTitle = CreateSqlParameter("Title", title);

            try
            {
                _authenticateDbContext.Database.ExecuteSqlRaw("exec GrantAspNetUserStandardRightsForPersonnel @AspNetUserId, @Office, @Title", paramUserId, paramOffice, paramTitle);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void CreateSecurityLoginDb(string userName)
        {
            var nameParameter = new SqlParameter
            {
                ParameterName = "@Username",
                IsNullable = false,
                Direction = ParameterDirection.Input,
                DbType = DbType.String,
                Value = userName
            };

            try
            {
                _authenticateDbContext.Database.ExecuteSqlRaw("exec CreateDatabaseHoldingUser @Username ", nameParameter);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static async Task<ApplicationUser> CreateIdentityUser(UserManager<ApplicationUser> userManager, string userName, string password, string email)
        {
            var employeeWorker = new EmployeeWorker();

            try
            {
                var employeeId = await employeeWorker.CreateEmployee();
                var newUser = new ApplicationUser {UserName = userName, Email = email, TableName = "Employee", TableId = employeeId, NormalizedUserName = userName.ToUpper()};
                await userManager.CreateAsync(newUser, password);
                await employeeWorker.UpdateEmployeeAspNetUserIdByEmployeeId(employeeId, newUser.Id);

                return newUser;
            }
            catch (Exception)
            {
                throw new Exception("Cannot create application user");
            }
        }
    }
}