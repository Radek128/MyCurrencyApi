namespace MyCurrencyApi.Domain.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException(string message) : base(message)
        {

        }

        public EntityNotFoundException(Type type, object entityId) : this($"{type.Name} with id: {entityId} not found") { }
    }
}
