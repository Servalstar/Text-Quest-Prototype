using Code.Services;

namespace Code.Rooms
{
    public class Tavern : BaseRoom
    {
        private readonly PlayerConsole _console;

        public Tavern(PlayerConsole console) =>
            _console = console;

        public override string Name => "Таверна";

        public override void Enter() => 
            _console.Print(Name, Commands);
    }
}