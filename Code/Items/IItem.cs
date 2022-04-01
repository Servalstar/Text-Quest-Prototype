namespace Code.Items
{
    public interface IItem
    {
        ItemType Type { get; }
        string Name { get; }
    }
}