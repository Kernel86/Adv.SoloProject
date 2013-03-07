using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CCreditCardTypes
    {
        // Private Fields
        private List<CCreditCardType> _glItems;

        // Public Properties
        public List<CCreditCardType> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CCreditCardType this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CCreditCardTypes()
        {
            _glItems = new List<CCreditCardType>();
        }

        // Events
        public event EventHandler CreditCardTypesChanged;

        // Public Methods
        public void Add(CCreditCardType oItem)
        {
            _glItems.Add(oItem);
            if (!CreditCardTypesChanged.Equals(null))
                CreditCardTypesChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (!CreditCardTypesChanged.Equals(null))
                CreditCardTypesChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select CreditCardTypes using LINQ
            var otblCreditCardTypes = from c in oDc.tblCreditCardTypes select c;

            // Fill generic list of CreditCardTypes
            foreach (tblCreditCardType otblCreditCardType in otblCreditCardTypes)
            {
                CCreditCardType oCreditCardType = new CCreditCardType(otblCreditCardType);
                _glItems.Add(oCreditCardType);
            }

            oDc = null;
        }
    }
}
