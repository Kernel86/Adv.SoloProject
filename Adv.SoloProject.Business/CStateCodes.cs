using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CStateCodes
    {
        // Private Fields
        private List<CStateCode> _glItems;

        // Public Properties
        public List<CStateCode> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CStateCode this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CStateCodes()
        {
            _glItems = new List<CStateCode>();
        }

        // Events
        public event EventHandler StateCodesChanged;

        // Public Methods
        public void Add(CStateCode oItem)
        {
            _glItems.Add(oItem);
            if (StateCodesChanged != null)
                StateCodesChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (StateCodesChanged != null)
                StateCodesChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select customers using LINQ
            var otblStateCodes = from c in oDc.tblStateCodes select c;

            // Fill generic list of customers
            foreach (tblStateCode otblStateCode in otblStateCodes)
            {
                CStateCode oStateCode = new CStateCode(otblStateCode);
                _glItems.Add(oStateCode);
            }

            oDc = null;
        }
    }
}
