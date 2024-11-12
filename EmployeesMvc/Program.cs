using EmployeesMvc.Models;

namespace EmployeesMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //St�d f�r Controllers och Views
            builder.Services.AddControllersWithViews();

            // Transient = Ny instans varje g�ng.
            // H�mtar allts� en ny instans av DataService varje g�ng vi beh�ver den.
            // "inte static"
            //builder.Services.AddTransient<DataService>();

            // Singleton = En instans som lever hela livsl�ngden av applikationen.
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
