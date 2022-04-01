using Code.Player;
using Code.Rooms;
using Code.Services;

namespace Code.CompositionRoot
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var console = new PlayerConsole();
            var progress = new PlayerProgress();
            var rooms = new RoomsStateMachine(console, progress);

            rooms.Enter<Tavern>();
        }
    }
}