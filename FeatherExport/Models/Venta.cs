using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatherExport.Models
{
    public class Transaccion
    {
        //public int id { get; set; } 
        public string employee { get; set; }
        public decimal check { get; set; }
        public decimal date { get; set; }
        public decimal sysdate { get; set; }
        public int ventatype { get; set; } //descuento - promo
        public string typeid { get; set; }
        public decimal ident { get; set; }
        public int auth { get; set; }
        public string unit { get; set; }
        public decimal amount { get; set; }
        public decimal tip { get; set; }
        public string manager { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int seconds { get; set; }


    }

    public class Detalle {
        public int type { get; set; }
        public string employee { get; set; }
        public string check { get; set; }
        public string item { get; set; }
        public string itemclass {get;set;}
        public string period { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        public int taxid { get; set; }
        public decimal price { get; set; }
        public string unit { get; set; }
        public string dob { get; set; }
        public string sysdate { get; set; }
        public int quantity { get; set; }
        public decimal discpric { get; set; }
        public decimal incltax { get; set; }
        public decimal bohname { get; set; }
        public string unitname { get; set; }
        public string tableid { get; set; }

}
}
