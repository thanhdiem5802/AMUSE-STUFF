namespace Coffee.WebUI.Models
{
    public record Response(
        int error,
        String message,
        object? data
    );
}
