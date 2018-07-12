using System.Collections.Generic;

namespace ETicModels.Entities
{
    public class Category:CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        

    }
}
