namespace WebApiFavorites.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
