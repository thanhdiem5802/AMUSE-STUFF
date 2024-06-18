namespace Coffee.WebUI.Models
{
    public record CreatePaymentLinkRequest(
        string productName,
        string description,
        int price,
        string returnUrl,
        string cancelUrl
    );
}
