using eticaret_business.Concrete;
using eticaret_data.Abstract;
using eticaret_data.Concrete.SQL;
using eticaret_v2.EmailServices;
using eticaret_v2.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            //services.AddServerSideBlazor();
            //services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(@"Server=P3NWPLSK12SQL-v06.shr.prod.phx3.secureserver.net;Database=eticaret_v2;user=tugb;password=Az2580139_;TrustServerCertificate=True"));
            //services.AddDbContext<artContext>(options => options.UseSqlServer(@"Server=P3NWPLSK12SQL-v06.shr.prod.phx3.secureserver.net;Database=eticaret_v2;user=tugb;password=Az2580139_;TrustServerCertificate=True"));
            services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            //services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<artContext>().AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options => {
                // password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".eticaret_v2.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });


            services.AddControllersWithViews();
            services.AddScoped<SqlProductRepository>();
            services.AddScoped<ProductManager>();
            services.AddScoped<CategoryManager>();
            ////services.AddScoped<SqlCardRepository>();
            //////services.AddScoped<SqlOrderRepository>();
            services.AddScoped<CardManager>();
            //services.AddScoped<OrderManager>();
            services.AddScoped<CommentManager>();
            //services.AddScoped<IOrderRepository, SqlOrderRepository>();

            services.AddScoped<SmtpEmailSender>(i=>
                new SmtpEmailSender(
                    Configuration["EmailSender:host"],                    
                    Configuration.GetValue<int>("EmailSender:port"),
                    Configuration.GetValue<bool>("EmailSender:enableSSL"),
                    Configuration["EmailSender:username"],
                    Configuration["EmailSender:password"]
                )
            ); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseDeveloperExceptionPage();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "products",
                //    pattern: "products/{page?}",
                //    defaults: "{controller=Home}/{action=List}");
                //endpoints.MapControllerRoute(
                //    name: "products",
                //    pattern: "products/{category?}",
                //    defaults: "{controller=Home}/{action=List}");

                //endpoints.MapControllerRoute(
                //    name: "adminroleedit",
                //    pattern: "admin/role/{id?}",
                //    defaults: new { controller = "Admin", action = "RoleEdit" }
                //);
                //endpoints.MapControllerRoute(
                //    name: "card",
                //    pattern: "Card/Index/{id?}",
                //    defaults: new { controller = "Card", action = "Indexc" }
                //);


                //endpoints.MapControllerRoute(
                //    name: "home/ProductComment",
                //    pattern: "home/Comment/{id?}",
                //    defaults: new { controller = "Home", action = "Comment" }
                //);


                endpoints.MapControllerRoute(
                    name: "List/Özgür Yapraklar",
                    pattern: "eticaret/List/Özgür Yapraklar",
                    defaults: new { controller = "eticaret", action = "List/Özgür Yapraklar" }
                );
                endpoints.MapControllerRoute(
                    name: "List/Minyatür",
                    pattern: "eticaret/List/Minyatür",
                    defaults: new { controller = "eticaret", action = "List/Minyatür" }
                );
                endpoints.MapControllerRoute(
                    name: "List/Yagli Boyalar",
                    pattern: "eticaret/List/Yagli Boyalar",
                    defaults: new { controller = "eticaret", action = "List/Yagli Boyalar" }
                );
                endpoints.MapControllerRoute(
                    name: "List/Sulu Boyalar",
                    pattern: "eticaret/List/Sulu Boyalar",
                    defaults: new { controller = "eticaret", action = "List/Sulu Boyalar" }
                );
                endpoints.MapControllerRoute(
                    name: "Iletisim",
                    pattern: "home/iletisim/{id?}",
                    defaults: new { controller = "Home", action = "Iletisim" }
                );
                //endpoints.MapControllerRoute(
                //    name: "Orders",
                //    pattern: "card/user/{id?}",
                //    defaults: new { controller = "Card", action = "GetOrders" }
                //);
                endpoints.MapControllerRoute(
                    name: "checkout",
                    pattern: "Checkout",
                    defaults: new { controller = "Card", action = "Checkout" }
                );
                endpoints.MapControllerRoute(
                    name: "Indexc",
                    pattern: "Indexc",
                    defaults: new { controller = "Card", action = "Indexc" }
                );
                endpoints.MapControllerRoute(
                    name: "adminuserlist",
                    pattern: "admin/user/{id?}",
                    defaults: new { controller = "Admin", action = "UserEdit" }
                );
                endpoints.MapControllerRoute(
                    name: "UsersList",
                    pattern: "UsersList",
                    defaults: new { controller = "Admin", action = "UsersList" }
                );
                endpoints.MapControllerRoute(
                    name: "adminusercreate",
                    pattern: "admin/user/{id?}",
                    defaults: new { controller = "Admin", action = "UserCreate" }
                );
                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "admin/role/{id?}",
                    defaults: new { controller = "Admin", action = "RoleCreate" }
                );

                endpoints.MapControllerRoute(
                    name: "adminrolelist",
                    pattern: "admin/role/{id?}",
                    defaults: new { controller = "Admin", action = "RoleList" }
                );

                endpoints.MapControllerRoute(
                    name: "adminproductlist",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "Edit" }
                );
                endpoints.MapControllerRoute(
                    name: "adminproductlist",
                    pattern: "admin/categorys/{id?}",
                    defaults: new { controller = "Admin", action = "CategoryEdit" }
                );
            
            endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{category?}");
            });
        }
    }
}
