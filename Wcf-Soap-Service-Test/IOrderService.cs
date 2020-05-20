using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Wcf_Soap_Service_Test
{
    [ServiceContract]
    public interface IOrderService
    {
        // Expose this service as both of REST and WCF soap
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "orders/count", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int GetOrdersCount();

        [OperationContract]
        Order GetByOrderNo(int orderNo);

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        IEnumerable<Order> GetOrdersByDate(string date);

        [OperationContract]
        IEnumerable<Order> GetOrders();

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        IEnumerable<Order> GetOrdersByType(string type);

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        int CreateOrder(Order order);

        [OperationContract]
        void UpdateOrder(Order order);

        [OperationContract]
        bool RemoveOrder(int orderNo);
    }

    [DataContract]
    public class Address
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string StreetAddress1 { get; set; }
        [DataMember]
        public string StreetAddress2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string Country { get; set; }
    }

    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderNo { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public double Value { get; set; }
        [DataMember]
        public double Discount { get; set; }
        [DataMember]
        public Address DeliveryAddress { get; set; }
        [DataMember]
        public DateTime OrderedDate { get; set; }
    }

    [DataContract]
    public class FaultInfo 
    {
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
