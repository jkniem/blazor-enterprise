using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.UI.Interfaces;
using ManagerExpenseApprovalService = BethanysPieShopHRM.UI.Services.ManagerExpenseApprovalService;

namespace BethanysPieShopHRM.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

            var pieShopUri = new Uri("https://localhost:44340");
            var recruitUri = new Uri("https://localhost:5001");

            void RegisterTypedClient<TClient, TImplementation>(Uri apiBaseUrl)
                where TClient : class where TImplementation : class, TClient
            {
                services.AddHttpClient<TClient, TImplementation>(client =>
                {
                    client.BaseAddress = apiBaseUrl;
                });
            }

            // HTTP services
            RegisterTypedClient<IEmployeeDataService, EmployeeDataService>(pieShopUri);
            RegisterTypedClient<ICountryDataService, CountryDataService>(pieShopUri);
            RegisterTypedClient<IJobCategoryDataService, JobCategoryDataService>(pieShopUri);
            RegisterTypedClient<ITaskDataService, TaskDataService>(pieShopUri);
            RegisterTypedClient<ISurveyDataService, SurveyDataService>(pieShopUri);
            RegisterTypedClient<IExpenseDataService, ExpenseDataService>(pieShopUri);
            RegisterTypedClient<IJobDataService, JobDataService>(recruitUri);

            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IExpenseApprovalService, ManagerExpenseApprovalService>();

            services.AddProtectedBrowserStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
