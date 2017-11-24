namespace PhotoShare.Client.Core
{
    using Microsoft.Extensions.DependencyInjection;
    using PhotoShare.Services.Contracts;
    using System;
    using System.Linq;

    public class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var databaseInitializerService = serviceProvider.GetService<IDatabaseInitializerService>();
            databaseInitializerService.InitializeDatabase();

            while (true)
            {
                Console.Write("Enter command: ");
                var input = Console.ReadLine();

                var commandTokens = input.Split(' ');

                var commandName = commandTokens.First();

                var commandArgs = commandTokens.Skip(1).ToArray();

                try
                {
                    var command = CommandParser.ParseCommand(serviceProvider, commandName);

                    var result = command.Execute(commandName, commandArgs);

                    Console.WriteLine(result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
