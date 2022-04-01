using Code.Rooms;

namespace Code.CompositionRoot.Factories
{
    public interface IRoomFactory
    {
        BaseRoom Create();
    }
}