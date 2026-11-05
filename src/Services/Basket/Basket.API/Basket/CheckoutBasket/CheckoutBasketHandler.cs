namespace Basket.API.Basket.CheckoutBasket;
public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);
public class CheckoutBasketCommandHandler
    (IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        // 1. Get existing basket with total price
        var basket = await basketRepository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        if (basket is null)
        {
            return new CheckoutBasketResult(false);
        }

        // 2. Set total price on basket checkout event message
        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        // 3. Send basket checkout event to rabbitmq using masstransit
        await publishEndpoint.Publish(eventMessage, cancellationToken);

        // 4. Delete the basket
        await basketRepository.DeleteBasket(
            command.BasketCheckoutDto.UserName,
            cancellationToken);

        return new CheckoutBasketResult(true);
    }
}