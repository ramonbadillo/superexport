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
        public string check { get; set; }
        public decimal date { get; set; }
        public decimal sysdate { get; set; }
        public int ventatype { get; set; } //descuento - promo
        public string typeid { get; set; }
        public string ident { get; set; }
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
        public string camporaro { get; set; }
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

    public class IttMove {
        public int Move_Cust_ID { get; set; } = 1;
        public int Move_Oper_ID { get; set; } = 2;
        public DateTime Move_Date { get; set; } //fechas
        public DateTime Move_Due_Date { get; set; }
        public DateTime Move_Fiscal_Date { get; set; }
        public string Move_Regi_Name { get; set; }
        public string Move_User_Login { get; set; }
        public string Move_host { get; set; }
        public decimal Move_Credit_Value { get; set; }
        public decimal Move_Cash_Value { get; set; }
        public decimal move_tip_Value { get; set; }
        public decimal Credit_tip { get; set; }
        public string Move_cashier { get; set; }
        public int Dine_type { get; set; }
        public string Table_name { get; set; }
        public int Cust_Id { get; set; }
        public string camaleon_ver { get; set; }
        public DateTime Move_Order_Created { get; set; }
        public int Move_Completed { get; set; } = 1;
        public int Move_amount_Tender { get; set; }
        public int Move_refer { get; set; }
        public int recipient_id { get; set; }
        public int add_id { get; set; }
        public int Billadd_id { get; set; }
        public int ticket_id { get; set; }
        public int Pay_inFull { get; set; }
        public int Docu_type_ID { get; set; }
        public int EZway_order { get; set; } = 0;
        public int move_Delivery_Value { get; set; }
        public int dine_option { get; set; }
        public int deliv_serv_id { get; set; } = 0;
        public int Ser_Charge { get; set; } = 0;

        List<DetaMove> DetaMoves { get; set; }

    }

    public class DetaMove {
        public int Move_Deta_Move_ID { get; set; }
        public string Move_Deta_ITEM_ID { get; set; }
        public int Subitem_of { get; set; }
        public decimal Move_Deta_Q { get; set; }
        public decimal Move_Deta_price { get; set; }
        public decimal Move_Deta_Tax_Value { get; set; }
        public decimal Move_Deta_Tax2_Value { get; set; }
        public decimal Move_Deta_Tax3_Value { get; set; }
        public decimal Move_REG_price { get; set; }
        public DateTime Date_complete { get; set; }
        public int order_host { get; set; }
        public string Order_Regi_name { get; set; }
        public int sent_to { get; set; }
        public int modi { get; set; }
        public string Order_Item_PREFERENCE { get; set; }
        public int origi_cuentaID { get; set; }
        public DateTime Order_Time_in { get; set; }
        public int item_complete { get; set; }
        public int Order_Table_name { get; set; }
        public string Order_Item_ID { get; set; }
        public int wilcu_gaid { get; set; }
    }

}
