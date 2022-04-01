using Code.Services;
using System.Collections.Generic;

namespace Code.Commands
{
    public class ReturnToCommands : ICommand
    {
        private readonly PlayerConsole _playerConsole;
        private readonly IEnumerable<ICommand> _commands;

        public string Description => "Продолжить";

        public ReturnToCommands(PlayerConsole playerConsole, IEnumerable<ICommand> commands)
        {
            _playerConsole = playerConsole;
            _commands = commands;
        }

        public void Execute() => 
            _playerConsole.Print("", _commands);
    }
}