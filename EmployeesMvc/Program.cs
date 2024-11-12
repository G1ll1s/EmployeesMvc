using EmployeesMvc.Models;

namespace EmployeesMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Stöd för Controllers och Views
            builder.Services.AddControllersWithViews();

            // Transient = Ny instans varje gång.
            // Hämtar alltså en ny instans av DataService varje gång vi behöver den.
            // "inte static"
            //builder.Services.AddTransient<DataService>();

            // Singleton = En instans som lever hela livslängden av applikationen.
            // "static"
            //builder.Services.AddSingleton<IDataService, DataService>(); ////Databas 1
            builder.Services.AddSingleton<IDataService, AnotherDataService>(); //Databas 2


            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employees}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
