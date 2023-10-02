//using eticaret_data.Concrete.SQL;
//using eticaret_v2.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eticaret_v2.Extensions
//{
//    public static class MigrationManager
//    {
//        public static IHost MigrationManager(this IHost host)
//        {
//            using (var scope = host.Services.CreateScope())
//            {
//                using (var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
//                {
//                    try
//                    {
//                        applicationContext.Database.Migrate();
//                    }
//                    catch(System.Exception)
//                    {
//                        throw;
//                    }
//                }
//                using (var artcontext = scope.ServiceProvider.GetRequiredService<artContext>())
//                {
//                    try
//                    {
//                        artcontext.Database.Migrate();
//                    }
//                    catch (System.Exception)
//                    {
//                        throw;
//                    }
//                }
//            }
//            return host;
//        }
//    }
//}
