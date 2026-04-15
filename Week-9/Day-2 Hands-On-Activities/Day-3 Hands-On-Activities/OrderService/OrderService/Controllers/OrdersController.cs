using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _db;
        private readonly IHttpClientFactory _httpClientFactory;

        public OrdersController(OrderDbContext db, IHttpClientFactory httpClientFactory)
        {
            _db = db;
            _httpClientFactory = httpClientFactory;
        }

        // ✅ CREATE ORDER
        [HttpPost("{productId}")]
        public async Task<IActionResult> CreateOrder(int productId)
        {
            var client = _httpClientFactory.CreateClient("ProductService");

            var product = await client.GetFromJsonAsync<Product>($"api/products/{productId}");

            if (product == null)
                return NotFound("Product not found");

            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                OrderDate = DateTime.UtcNow
            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return Ok(order);
        }

        // ✅ GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _db.Orders.ToListAsync();
            return Ok(orders);
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _db.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // ✅ UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Order updatedOrder)
        {
            var order = await _db.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            order.ProductName = updatedOrder.ProductName;
            order.Price = updatedOrder.Price;

            await _db.SaveChangesAsync();

            return Ok(order);
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _db.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}