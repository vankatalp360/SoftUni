namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using PhotoShare.Services;
    using PhotoShare.Services.Contracts;
    using System;

    public class Application
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            Engine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<PhotoShareContext>(options =>
                options.UseSqlServer(ServerConfig.ConnectionString)
            );

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IAlbumRoleService, AlbumRoleService>();
            serviceCollection.AddTransient<IAlbumService, AlbumService>();
            serviceCollection.AddTransient<IAlbumTagService, AlbumTagService>();
            serviceCollection.AddTransient<IFriendshipService, FriendshipService>();
            serviceCollection.AddTransient<IPictureService, PictureService>();
            serviceCollection.AddTransient<ITagService, TagService>();
            serviceCollection.AddTransient<ITownService, TownService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
