using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ETicModels.Entities
{
    public class CoreEntity
    {
        public CoreEntity()
        {
            this.CreateDate = DateTime.Now;
            this.IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            this.MachineName = Environment.MachineName;
        }
        
        public int ID { get; set; }
        public string Createdby { get; set; }
        public string IP { get; set; }
        public string MachineName { get; set; }
        [Column(TypeName ="datetime2")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDate { get; set; }
    }
}
