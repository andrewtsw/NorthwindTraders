using System;
using System.Collections.Generic;
using System.Linq;
using Dotnext.Domain.Common;

namespace Dotnext.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Shipper Shipper { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; private set; }

        public decimal CalculateTotalPrice()
        {
            var subTotal = OrderDetails.Sum(x => x.CalculatePrice());
            var discount = CalculateDiscount();
            var tax = CalculateTax();
            return subTotal - discount + tax;
        }

        public decimal CalculateDiscount()
        {
            // TODO:
            return 0;
        }

        public decimal CalculateTax()
        {
            // TODO:
            return 0;
        }
    }
}
