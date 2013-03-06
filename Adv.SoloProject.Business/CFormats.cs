using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            if (!FormatsChanged.Equals(null))
                FormatsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (!FormatsChanged.Equals(null))
                FormatsChanged(this, new EventArgs());
        }
    }
}
