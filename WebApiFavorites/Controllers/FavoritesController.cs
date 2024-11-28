using Microsoft.AspNetCore.Mvc;
using WebApiFavorites.Models;

namespace WebApiFavorites.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoritesController : ControllerBase
{

    private static List<Favorite> _favorites = new List<Favorite>
    {
        new Favorite { FavoriteId = 1, UserId = "123", ProductId = "400", CreatedAt = DateTime.Now },
        new Favorite { FavoriteId = 2, UserId = "123", ProductId = "500", CreatedAt = DateTime.Now }
    };

    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<Favorite>> GetFavorites(string userId)
    {
        var userFavorites = _favorites.Where(f => f.UserId == userId).ToList();
        return Ok(userFavorites);
    }


    [HttpPost]
    public ActionResult<Favorite> AddFavorite([FromBody] Favorite favorite)
    {

        if (_favorites.Any(f => f.UserId == favorite.UserId && f.ProductId == favorite.ProductId))
        {
            return BadRequest("Product is already in favorites.");
        }

        favorite.FavoriteId = _favorites.Any() ? _favorites.Max(f => f.FavoriteId) + 1 : 1;
        favorite.CreatedAt = DateTime.Now;
        _favorites.Add(favorite);

        return Ok(favorite);
    }

    [HttpDelete("{favoriteId}")]
    public IActionResult DeleteFavorite(int favoriteId)
    {
        var favorite = _favorites.FirstOrDefault(f => f.FavoriteId == favoriteId);
        if (favorite == null)
        {
            return NotFound();
        }

        _favorites.Remove(favorite);
        return NoContent();
    }
}
