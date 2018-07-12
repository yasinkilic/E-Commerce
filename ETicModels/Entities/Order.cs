using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicModels.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
            Order_Details = new HashSet<Order_Details>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public ICollection<Order_Details> Order_Details { get; set; }

    }
}
