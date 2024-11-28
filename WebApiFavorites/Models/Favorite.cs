using System.ComponentModel.DataAnnotations;

namespace WebApiFavorites.Models;

public class Favorite
{
    [Key]
    public int FavoriteId { get; set; }
    public string? UserId { get; set; }
    public string? ProductId { get; set; }
    public DateTime CreatedAt { get; set; }

}
