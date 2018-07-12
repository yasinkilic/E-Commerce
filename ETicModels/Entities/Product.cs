using System.Collections.Generic;

namespace ETicModels.Entities
{
    public class Product:CoreEntity
    {
     
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get {return Quantity* Price; } }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public List<Comment> Comments { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}
