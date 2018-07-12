using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicModels.Entities
{
    [Table("Order Details")]
    public class Order_Details
    {
        [Key]
        public int OrderID { get; set; }
        [Column(Order =1)]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
    }
}
