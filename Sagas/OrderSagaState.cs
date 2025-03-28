using Entities;
using Sagas.Enum;

namespace Sagas;

public class OrderSagaState
{
    public Guid CorrelationId { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
    
    public string CurrentState { get; set; }
}