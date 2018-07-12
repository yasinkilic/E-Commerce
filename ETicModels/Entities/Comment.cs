using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicModels.Entities
{
    [Table("Comments")]
   public class Comment:CoreEntity
    {
        [Display(Name ="Comment")]
        public string Cmmnt { get; set; }
        public string CmmntName { get; set; }
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
    }
}
