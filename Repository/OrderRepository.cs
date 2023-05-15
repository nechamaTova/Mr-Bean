using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        static int idCounter = 22;
        Store214089435Context _Store214089435;

        public OrderRepository(Store214089435Context Store214089435)
        {
            this._Store214089435 = Store214089435;
        }

        public async Task<Order> AddOrder(Order order)
        {
            //foreach(OrderItem oi in order.OrderItems)
            //{
            //    oi.OrderItemId = idCounter++;
            //}
            await _Store214089435.Orders.AddAsync(order);
            await _Store214089435.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order =  await _Store214089435.Orders.Include(order=>order.OrderItems).Where(order=>order.OrderId==id).ToListAsync();
            return order != null ? order[0] : null;
        }
    }
}
