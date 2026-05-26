using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using EcoTechStore.Models;
using EcoTechStore.Helpers;

namespace EcoTechStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private const string SessionCartKey = "Cart";

        [HttpGet("count")]
        public IActionResult GetCartCount()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();
            var totalItems = cart.Sum(item => item.Quantity);

            return Ok(new { count = totalItems });
        }
    }
}
