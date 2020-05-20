using System.Collections.Generic;

namespace Wcf_Soap_Service_Test.DataAccess
{
    interface IOrderDataAccess
    {
        Order GetById(int id);
        int Create(Order order);
        int GetOrdersCount();
        void Update(Order order);
        bool Delete(int id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByType(string type);
        IEnumerable<Order> GetByDate(string date);
    }
}
