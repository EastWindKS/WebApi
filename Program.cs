using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Data.Context;
using WebAPI.Data.Interfaces.Addresses;
using WebAPI.Data.Interfaces.Finances;
using WebAPI.Data.Interfaces.Organizations;
using WebAPI.Data.Interfaces.Services;
using WebAPI.Data.Repositories.Addresses;
using WebAPI.Data.Repositories.Finances;
using WebAPI.Data.Repositories.Identity;
using WebAPI.Data.Repositories.Organizations;
using WebAPI.Data.Repositories.Services;
using WebAPI.Models.Authenticate;
using WebAPI.Security.Authenticate;
using WebAPI.Services.JWT;
using WebAPI.Services.Novell;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<AuthenticateDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AuthenticateDbContext>().AddDefaultTokenProviders();


#region JWT

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>()?.HttpContext?.User);

#region Injections

builder.Services.AddScoped<IAuthenticate, Authenticate>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IFilterListRepository, FilterListRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IOrganizationLegalFormRepository, OrganizationLegalFormRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddSingleton<IJwtWorker, JwtWorker>();
builder.Services.AddSingleton<INovellWorker, NovellWorker>();
builder.Services.AddSingleton<IIdentityRepository, IdentityRepository>();
builder.Services.AddSingleton<IDbContextFactory, DbContextFactory>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b => { b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();