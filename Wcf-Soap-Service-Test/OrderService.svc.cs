using System.Collections.Generic;
using System.ServiceModel;
using Wcf_Soap_Service_Test.DataAccess;

namespace Wcf_Soap_Service_Test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderService.svc or OrderService.svc.cs at the Solution Explorer and start debugging.
    public class OrderService : IOrderService
    {
        private readonly IOrderDataAccess orderDataAccess;
        private readonly FaultInfo faultInfo;
        public OrderService()
        {
            orderDataAccess = new OrderDataAccess();
            faultInfo = new FaultInfo();
        }

        public int CreateOrder(Order order)
        {
            if (order != null && order.Value != 0)
            {
                return orderDataAccess.Create(order);
            }
            else
            {
                faultInfo.ErrorMessage = "Order details are empty and cannot create a new order.";
                throw new FaultException<FaultInfo>(faultInfo, "Order details are empty and cannot create a new order.");
            }
        }

        public Order GetByOrderNo(int orderNo)
        {
            return orderDataAccess.GetById(orderNo);
        }

        public IEnumerable<Order> GetOrders()
        {
            return orderDataAccess.GetAll();
        }

        public IEnumerable<Order> GetOrdersByDate(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                return orderDataAccess.GetByDate(date); 
            }
            else
            {
                faultInfo.ErrorMessage = "Date string is empty or null.";
                throw new FaultException<FaultInfo>(faultInfo, "Date string is empty or null");
            }
        }

        public IEnumerable<Order> GetOrdersByType(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                return orderDataAccess.GetByType(type); 
            }
            else
            {
                faultInfo.ErrorMessage = "Order type is empty or null.";
                throw new FaultException<FaultInfo>(faultInfo, "Order type is empty or null");
            }
        }

        public int GetOrdersCount()
        {
            return orderDataAccess.GetOrdersCount();
        }

        public bool RemoveOrder(int orderNo)
        {
            return orderDataAccess.Delete(orderNo);
        }

        public void UpdateOrder(Order order)
        {
            orderDataAccess.Update(order);
        }
    }
}
