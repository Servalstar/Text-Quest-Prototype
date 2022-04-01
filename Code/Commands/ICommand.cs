namespace Code.Commands
{
    public interface ICommand
    {
        string Description { get; }
        void Execute();
    }
}