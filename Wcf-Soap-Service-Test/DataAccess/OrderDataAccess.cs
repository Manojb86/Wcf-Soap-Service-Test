using System;
using System.Collections.Generic;
using System.Linq;

namespace Wcf_Soap_Service_Test.DataAccess
{
    public class OrderDataAccess : IOrderDataAccess
    {
        private List<Order> orders => new List<Order> {
            new Order { OrderNo = 1, Value = 10.50, Discount = 2.50, Description = "soap", OrderedDate = DateTime.Today, Type = "Basic"
                ,DeliveryAddress = new Address { Name = "Manoj b", StreetAddress1 = "Madapatha road", City = "Colombo", Country = "Sri Lanka", ZipCode = "10650" } 
            },
            new Order { OrderNo = 2, Value = 20.50, Discount = 2.50, Description = "Fruits", OrderedDate = DateTime.Today, Type = "Basic"
                ,DeliveryAddress = new Address { Name = "Asiri b", StreetAddress1 = "Galle road", City = "Colombo", Country = "Sri Lanka", ZipCode = "10550" } 
            },
            new Order { OrderNo = 3, Value = 20.50, Discount = 2.50, Description = "Vegetables", OrderedDate = DateTime.Today, Type = "Basic"
                , DeliveryAddress = new Address { Name = "Nuwan L", StreetAddress1 = "Kandy road", City = "Colombo", Country = "Sri Lanka", ZipCode = "11550" }
            },
            new Order { OrderNo = 4, Value = 20.50, Discount = 2.50, Description = "Meats", OrderedDate = DateTime.Today, Type = "Basic"
                , DeliveryAddress = new Address { Name = "Lasith N", StreetAddress1 = "Jaffna road", City = "Colombo", Country = "Sri Lanka", ZipCode = "13550" } 
            },
            new Order { OrderNo = 5, Value = 20.50, Discount = 2.50, Description = "Rice and dry foods", OrderedDate = DateTime.Today, Type = "Basic"
                , DeliveryAddress = new Address { Name = "Malith c", StreetAddress1 = "Airport road", City = "Colombo", Country = "Sri Lanka", ZipCode = "13550" } 
            },
        };

        public int Create(Order order)
        {
            if (order != null)
            {
                orders.Add(order);
                return order.OrderNo;
            }

            return 0;
        }

        public bool Delete(int id)
        {
            if (id > 0)
            {
                var order = orders.FirstOrDefault(x => x.OrderNo == id);
                if (order != null)
                {
                    orders.Remove(order);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<Order> GetAll()
        {
            return orders;
        }

        public IEnumerable<Order> GetByDate(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                DateTime dateTime = Convert.ToDateTime(date);
                return orders.Where(x => x.OrderedDate.Equals(dateTime));
            }

            return null;
        }

        public Order GetById(int id)
        {
            if (id > 0)
            {
                var order = orders.FirstOrDefault(x => x.OrderNo == id);
                return order;
            }

            return null;
        }

        public IEnumerable<Order> GetByType(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                return orders.Where(x => x.Type.Equals(type));
            }

            return null;
        }

        public int GetOrdersCount()
        {
            return orders.Count;
        }

        public void Update(Order order)
        {
            if (order != null && orders.Any(x => x.OrderNo == order.OrderNo))
            {
                Delete(order.OrderNo);
                Create(order);
            }
        }
    }
}