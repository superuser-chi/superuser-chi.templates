using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class RECHARGEACCOUNTSTYPE
    {

        public RECHARGEACCOUNTSTYPE()
        {
            ZZSTR_CAN_RECHARGE_XML = new RECHARGEACCOUNTSTYPEZZSTR_CAN_RECHARGE_XML[] { };
        }
        private RECHARGEACCOUNTSTYPEZZSTR_CAN_RECHARGE_XML[] zZSTR_CAN_RECHARGE_XMLField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ZZSTR_CAN_RECHARGE_XML")]
        public RECHARGEACCOUNTSTYPEZZSTR_CAN_RECHARGE_XML[] ZZSTR_CAN_RECHARGE_XML
        {
            get
            {
                return this.zZSTR_CAN_RECHARGE_XMLField;
            }
            set
            {
                this.zZSTR_CAN_RECHARGE_XMLField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RECHARGEACCOUNTSTYPEZZSTR_CAN_RECHARGE_XML
    {

        private System.DateTime dATEField;

        private long aCCNOField;

        private string bPNOField;

        private string cURRENCYField;

        private decimal aMOUNTField;

        private string pAYMENTTYPEField;

        private string dOCNOField;

        private string rEFERENCE1Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime DATE
        {
            get
            {
                return this.dATEField;
            }
            set
            {
                this.dATEField = value;
            }
        }

        /// <remarks/>
        public long ACCNO
        {
            get
            {
                return this.aCCNOField;
            }
            set
            {
                this.aCCNOField = value;
            }
        }

        /// <remarks/>
        public string BPNO
        {
            get
            {
                return this.bPNOField;
            }
            set
            {
                this.bPNOField = value;
            }
        }

        /// <remarks/>
        public string CURRENCY
        {
            get
            {
                return this.cURRENCYField;
            }
            set
            {
                this.cURRENCYField = value;
            }
        }

        /// <remarks/>
        public decimal AMOUNT
        {
            get
            {
                return this.aMOUNTField;
            }
            set
            {
                this.aMOUNTField = value;
            }
        }

        /// <remarks/>
        public string PAYMENTTYPE
        {
            get
            {
                return this.pAYMENTTYPEField;
            }
            set
            {
                this.pAYMENTTYPEField = value;
            }
        }

        /// <remarks/>
        public string DOCNO
        {
            get
            {
                return this.dOCNOField;
            }
            set
            {
                this.dOCNOField = value;
            }
        }

        /// <remarks/>
        public string REFERENCE1
        {
            get
            {
                return this.rEFERENCE1Field;
            }
            set
            {
                this.rEFERENCE1Field = value;
            }
        }
    }


}
