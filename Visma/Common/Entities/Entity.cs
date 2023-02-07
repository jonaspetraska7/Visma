using LinqToDB.Mapping;

namespace Common.Entities
{
    public abstract class Entity
    {
        [PrimaryKey]
        public Guid Id { get; set; }
    }
}
