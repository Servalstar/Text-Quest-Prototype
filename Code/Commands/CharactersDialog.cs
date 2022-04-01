using Code.Characters;
using Code.Services;

namespace Code.Commands
{
    public class CharactersDialog : ICommand
    {
        private readonly PlayerConsole _playerConsole;
        private readonly Character _character;

        public string Description => $"Поговорить с {_character.Name}";

        public CharactersDialog(PlayerConsole playerConsole, Character character)
        {
            _playerConsole = playerConsole;
            _character = character;
        }

        public void Execute()
        {
            var dialog = _character.GetNextDialog();
            _playerConsole.Print($"Игрок: {dialog.Request} \n{_character.Name}: {dialog.Responce}", dialog.Commands);
        }
    }
}