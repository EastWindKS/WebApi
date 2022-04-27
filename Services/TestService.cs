using Microsoft.Data.SqlClient;

namespace WebAPI.Services;

public interface ITestService
{
    void Call();
}

public class TestService : ITestService
{
    private readonly IConfiguration _configuration;

    public TestService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Call()
    {
        var connectionString1 = _configuration.GetConnectionString("DefaultConnection");
        var connectionString2 = _configuration.GetConnectionString("OldGTI");

      //  SqlDependencyEx listener1 = new SqlDependencyEx(connectionString1, "GTIWeb", "Organization", identity: 1);
        SqlDependencyEx listener2 = new SqlDependencyEx(connectionString2, "GTIVFP", "a_type", identity: 2);


        listener2.TableChanged += (o, args) =>
        {
            Console.WriteLine("OLD GTI?");
            Console.WriteLine(args);
            Console.WriteLine(o);
        };

        listener2.Start();

        // listener1.TableChanged += (o, args) =>
        // {
        //     Console.WriteLine("OUR BASE?");
        //     Console.WriteLine(args);
        //     Console.WriteLine(o);
        // };
        //
        // listener1.Start();
    }
}