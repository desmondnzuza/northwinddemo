using KMC.Northwind.Demo.Core.Interface.BusinessLogic;
using KMC.Northwind.Demo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMC.Northwind.Demo.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderOperation _operation;

        public OrderController(IOrderOperation operation)
        {
            _operation = operation;
        }

        [HttpGet]
        public OrderStat[] FindOrdersBeingShipped()
        {
            return _operation.FindOrdersBeingShiped();
        }
    }
}