using Code.Characters;
using Code.Commands;
using System.Collections.Generic;

namespace Code.Rooms
{
    public abstract class BaseRoom
    {
        public abstract string Name { get; }

        private List<Character> _characters { get; } = new List<Character>();
        private List<ICommand> _commands { get; } = new List<ICommand>();

        public IEnumerable<Character> Characters => _characters;
        public IEnumerable<ICommand> Commands => _commands;
        
        public void AddCharacter(Character character) =>
            _characters.Add(character);

        public void AddCommand(ICommand command) =>
            _commands.Add(command);

        public abstract void Enter();
    }
}