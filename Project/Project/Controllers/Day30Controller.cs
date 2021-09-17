using System;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Day30;
using Project.Services.Day30;

namespace Project.Controllers
{
    public class Day30Controller : Controller
    {
        private readonly OrderService _orderService;

        public Day30Controller(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Case01()
        {
            ViewBag.OrdersJson = _orderService.GetOrders().ToJson();

            ViewBag.EmptyOrder         = new Order { Items = Array.Empty<OrderItem>(), }.ToJson();
            ViewBag.EmptyOrderItemJson = new OrderItem().ToJson();
            ViewBag.OrderItemsJson     = _orderService.GetOrderItems().ToJson();

            return View();
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult GetList()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Get([FromBody]int orderId)
        {
            var order = _orderService.GetOrder(orderId);
            return Ok(order);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult PostAdd([FromBody]Order vm)
        {
            Calculate(vm);

            _orderService.Add(vm);

            return Ok(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult PostEdit([FromBody]Order vm)
        {
            Calculate(vm);

            _orderService.Edit(vm);

            return Ok(vm);
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete([FromBody]int orderId)
        {
            _orderService.Delete(orderId);

            return Ok();
        }

        [HttpPost, Route("api/[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate([FromBody]Order vm)
        {
            if (vm?.Items?.Length > 0 == false)
            {
                return Ok(vm);
            }

            vm.SubTotalAmount = 0;
            foreach (var item in vm.Items)
            {
                item.Amount = item.UnitPrice * item.Quantity;

                vm.SubTotalAmount += item.Amount.GetValueOrDefault();
            }

            vm.Tax         = vm.SubTotalAmount * 0.05m;
            vm.TotalAmount = vm.SubTotalAmount * 1.05m;

            return Ok(vm);
        }
    }
}
