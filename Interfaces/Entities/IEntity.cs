namespace Interfaces.Entities
{
    public interface IEntity 
    {
        int SequentialId { get; }
        string BusinessId { get; }
    }
}