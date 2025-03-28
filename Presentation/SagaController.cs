using Microsoft.AspNetCore.Mvc;
using Orderseer.Common.Entities;
using Orderseer.Common.Extensions;
using Orderseer.Common.Models.Dto;

namespace Presentation;

[ApiController]
[Route("api/[controller]")]
public class SagaController: ControllerBase
{
    [HttpPost]
    [Route("process_order")]
    public async Task<IActionResult> ProcessOrder([FromBody] Order order)
    {
        var createOrderDto = order.ToCreateOrderDto();
        var orderResponse = await CreateOrder(createOrderDto);
        
        var reserveInventoryDto = order.ToReserveInventoryDto();
        var reserveResponse = await ReserveInventory(reserveInventoryDto);
        
        var processPaymentDto = order.ToProcessPaymentDto();
        var paymentResponse = await ProcessPayment(processPaymentDto);

        var processDeliveryDto = order.ToDeliveryDto();
        var deliveryResponse = await ProcessDelivery(processDeliveryDto);
    }
}