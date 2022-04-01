using Code.Services;

namespace Code.Commands
{
    public class PlayerDeath : ICommand
    {
        private readonly PlayerConsole _playerConsole;

        public string Description => "Оставить бродягу в покое";

        public PlayerDeath(PlayerConsole playerConsole) => 
            _playerConsole = playerConsole;

        public void Execute() => 
            _playerConsole.Print("Бродяга всадил Вам нож в спину как только Вы отвернулись \nКонец");
    }
}