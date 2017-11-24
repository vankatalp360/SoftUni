namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Commands.Contracts;
    using System;

    public class ExitCommand:ICommand
    {
        public string Execute(string command, params string[] arguments)
        {
            Environment.Exit(0);
            return "Bye-bye!";
        }
    }
}
