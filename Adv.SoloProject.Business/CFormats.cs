using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CFormats
    {
        // Private Fields
        private List<CFormat> _glItems;

        // Public Properties
        public List<CFormat> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CFormat this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CFormats()
        {
            _glItems = new List<CFormat>();
        }

        // Events
        public event EventHandler FormatsChanged;

        // Public Methods
        public void Add(CFormat oItem)
        {
            _glItems.Add(oItem);
            if (FormatsChanged != null)
                FormatsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (FormatsChanged != null)
                FormatsChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select customers using LINQ
            var otblFormats = from c in oDc.tblFormats orderby c.Description select c;

            // Fill generic list of customers
            foreach (tblFormat otblFormat in otblFormats)
            {
                CFormat oFormat = new CFormat(otblFormat);
                _glItems.Add(oFormat);
            }

            oDc = null;
        }
    }
}
