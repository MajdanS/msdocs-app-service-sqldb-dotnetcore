using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreSqlDb.Data;
using Microsoft.Build.Exceptions;





namespace DotNetCoreSqlDb.Data
{



    public class MyDatabaseContext : DbContext
    {
        /*     public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
                 : base(options)
             {
             }  */



    public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options, IHttpContextAccessor accessor)
             : base(options)
        {

            
            var conn = Database.GetDbConnection() as SqlConnection;
            conn.AccessToken = accessor.HttpContext.Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"];
        }

     /*   public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options, IHttpContextAccessor accessor)
               : base(options)
           {




               var conn = Database.GetDbConnection() as SqlConnection;
               conn.AccessToken = accessor.HttpContext.Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"];


           } */

        public DbSet<DotNetCoreSqlDb.Models.Todo> Todo { get; set; } = default!;
 


    }

}




