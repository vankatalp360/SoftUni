using MyBlogTest.Migrations;
using MyBlogTest.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(MyBlogTest.Startup))]
namespace MyBlogTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext,Configuration>());
            ConfigureAuth(app);
        }
    }
}
