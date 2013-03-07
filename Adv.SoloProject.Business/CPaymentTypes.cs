using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CPaymentTypes
    {
        // Private Fields
        private List<CPaymentType> _glItems;

        // Public Properties
        public List<CPaymentType> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CPaymentType this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CPaymentTypes()
        {
            _glItems = new List<CPaymentType>();
        }

        // Events
        public event EventHandler PaymentTypesChanged;

        // Public Methods
        public void Add(CPaymentType oItem)
        {
            _glItems.Add(oItem);
            if (PaymentTypesChanged != null)
                PaymentTypesChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (PaymentTypesChanged != null)
                PaymentTypesChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select PaymentTypes using LINQ
            var otblPaymentTypes = from c in oDc.tblPaymentTypes select c;

            // Fill generic list of PaymentTypes
            foreach (tblPaymentType otblPaymentType in otblPaymentTypes)
            {
                CPaymentType oPaymentType = new CPaymentType(otblPaymentType);
                _glItems.Add(oPaymentType);
            }

            oDc = null;
        }
    }
}
