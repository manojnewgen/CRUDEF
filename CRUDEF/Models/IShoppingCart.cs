using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEF.Models
{
    public interface IShoppingCart
    {
        object GetCart();
    }
    public class ShoppingCartCache : IShoppingCart
    {
        public object GetCart()
        {
            return "Cart loaded from cache.";
        }
    }
    public class ShoppingCartDB : IShoppingCart
    {
        public object GetCart()
        {
            return "Cart loaded from DB";
        }
    }
    public class ShoppingCartAPI : IShoppingCart
    {
        public object GetCart()
        {
            return "Cart loaded through API.";
        }
      
    }
    public interface IShoppingCartRepository
    {
        object GetCart();
    }
    public class Constants
    {
    }

    public enum CartSource
    {
        Cache = 1,
        DB = 2,
        API = 3
    }
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly Func<string, IShoppingCart> shoppingCart;
        public ShoppingCartRepository(Func<string, IShoppingCart> shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public object GetCart()
        {
            return shoppingCart(CartSource.DB.ToString()).GetCart();
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            services.AddSingleton<ShoppingCartCache>();
            services.AddSingleton<ShoppingCartDB>();
            services.AddSingleton<ShoppingCartAPI>();

            services.AddTransient<Func<string, IShoppingCart>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "API":
                        return serviceProvider.GetService<ShoppingCartAPI>();
                    case "DB":
                        return serviceProvider.GetService<ShoppingCartDB>();
                    default:
                        return serviceProvider.GetService<ShoppingCartCache>();
                }
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
