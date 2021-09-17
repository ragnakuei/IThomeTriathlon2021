using System;
using System.Collections.Generic;
using System.Linq;
using Project.Models.Day30;

namespace Project.Services.Day30
{
    public class OrderService
    {
        private static readonly List<Order> _orders
            = new()
              {
                  new Order
                  {
                      OrderId   = 1,
                      OrderDate = new DateTime(2021, 6, 1),
                      Items = new[]
                              {
                                  new OrderItem { OrderItemId = 1, UnitPrice = 100, Quantity = 2, Amount = 200 },
                                  new OrderItem { OrderItemId = 2, UnitPrice = 200, Quantity = 3, Amount = 600 },
                              },
                      SubTotalAmount = 800,
                      Tax            = 40,
                      TotalAmount    = 840,
                  },
                  new Order
                  {
                      OrderId   = 2,
                      OrderDate = new DateTime(2021, 6, 2),
                      Items = new[]
                              {
                                  new OrderItem { OrderItemId = 2, UnitPrice = 300, Quantity = 1, Amount = 300 },
                                  new OrderItem { OrderItemId = 3, UnitPrice = 500, Quantity = 5, Amount = 2500 },
                              },
                      SubTotalAmount = 2800,
                      Tax            = 140,
                      TotalAmount    = 2940,
                  },
                  new Order
                  {
                      OrderId   = 3,
                      OrderDate = new DateTime(2021, 6, 3),
                      Items = new[]
                              {
                                  new OrderItem { OrderItemId = 1, UnitPrice = 200, Quantity = 3, Amount = 600 },
                                  new OrderItem { OrderItemId = 3, UnitPrice = 400, Quantity = 2, Amount = 800 },
                              },
                      SubTotalAmount = 1400,
                      Tax            = 70,
                      TotalAmount    = 1470,
                  },
              };

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public Option[] GetOrderItems()
        {
            return new Option[]
                   {
                       new() { Value = 1, Text = "項目 A" },
                       new() { Value = 2, Text = "項目 B" },
                       new() { Value = 3, Text = "項目 C" },
                   };
        }

        public void Add(Order vm)
        {
            vm.OrderId = _orders.Count + 1;
            _orders.Add(vm);
        }

        public void Edit(Order vm)
        {
            var editOrder = _orders.FirstOrDefault(o => o.OrderId == vm.OrderId);

            editOrder.OrderDate      = vm.OrderDate;
            editOrder.Items          = vm.Items;
            editOrder.SubTotalAmount = vm.SubTotalAmount;
            editOrder.Tax            = vm.Tax;
            editOrder.TotalAmount    = vm.TotalAmount;
        }

        public Order GetOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            return order;
        }

        public void Delete(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);

            _orders.Remove(order);
        }
    }
}