namespace BootcampMarket.Core.Data.Entity
{
    public interface IEntity
    {
    }

    public interface IEntity<T> : IEntity where T: struct
    {
        public T Id { get; set; }
    }
}
