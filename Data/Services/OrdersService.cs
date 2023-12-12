using EStore.Data.Base;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Data.Services
{
    public class OrdersService :  IOrdersService
    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context) 
        {
            _context = context;
        }
       

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Product).Include(n => n.User).ToListAsync();

            if(userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderItems) // Include related order items
                                      .FirstOrDefaultAsync(o => o.Id == orderId);
           
            if (order != null)
            {
                // If there are related order items, remove them first
                _context.OrderItems.RemoveRange(order.OrderItems);

                // Now remove the order
                _context.Orders.Remove(order);

                // Save the changes to the database
                await _context.SaveChangesAsync();
            }

        }
}
    }