using Code.Items;
using Code.Player;
using Code.Services;

namespace Code.Commands
{
    public class RobCharacter : ICommand
    {
        private readonly PlayerConsole _playerConsole;
        private readonly ICommand _command;
        private readonly PlayerProgress _playerProgress;

        public string Description => "Забрать всё что у него есть";

        public RobCharacter(PlayerConsole playerConsole, ICommand command, PlayerProgress playerProgress)
        {
            _playerConsole = playerConsole;
            _command = command;
            _playerProgress = playerProgress;
        }

        public void Execute()
        {
            _playerProgress.AddCoins(50);
            _playerProgress.AddItem(new Medallion(), 1);

            _playerConsole.Print("Игрок получил медальон и 50 монет", _command);
        }
    }
}