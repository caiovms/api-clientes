using api_customer.cross.cutting.IOC;
using api_customer.data;
using api_customer.grpc.services.customer.Protos;
using api_customer.grpc.services.address.Protos;
using Autofac;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using api_customer.grpc.services.contact.Protos;

namespace api_customer.getway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomerContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Customer_DbConnection")));

            services.AddDbContext<AddressContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Address_DbConnection")));

            services.AddControllersWithViews();

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            services.AddGrpcClient<CustomerService.CustomerServiceClient>(o =>
            {
                o.Address = new Uri("http://localhost:5002");
                o.ChannelOptionsActions.Add(channelOptions => channelOptions.Credentials = ChannelCredentials.Insecure);
            });

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            services.AddGrpcClient<ContactService.ContactServiceClient>(o =>
            {
                o.Address = new Uri("http://localhost:5002");
                o.ChannelOptionsActions.Add(channelOptions => channelOptions.Credentials = ChannelCredentials.Insecure);
            });

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            services.AddGrpcClient<AddressService.AddressServiceClient>(o =>
            {
                o.Address = new Uri("http://localhost:5003");
                o.ChannelOptionsActions.Add(channelOptions => channelOptions.Credentials = ChannelCredentials.Insecure);
            });
        }

        public void ConfigureContainer(ContainerBuilder Builder)
        {
            Builder.RegisterModule(new ModuleIOC());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
