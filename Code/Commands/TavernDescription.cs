using Code.Services;

namespace Code.Commands
{
    public class TavernDescription : ICommand
    {
        private readonly PlayerConsole _playerConsole;
        private readonly ICommand _command;

        public string Description => "Осмотреть окрестности";

        public TavernDescription(PlayerConsole playerConsole, ICommand command)
        {
            _playerConsole = playerConsole;
            _command = command;
        }

        public void Execute() => 
            _playerConsole.Print("Грязное помещение с единственным посетителем возле стойки", _command);
    }
}