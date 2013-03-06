using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CRentalItems
    {
        // Private Fields
        private List<CRentalItem> _glItems;

        // Public Properties
        public List<CRentalItem> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CRentalItem this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CRentalItems()
        {
            _glItems = new List<CRentalItem>();
        }

        // Events
        public event EventHandler RentalItemsChanged;

        // Public Methods
        public void Add(CRentalItem oItem)
        {
            _glItems.Add(oItem);
            if (!RentalItemsChanged.Equals(null))
                RentalItemsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (!RentalItemsChanged.Equals(null))
                RentalItemsChanged(this, new EventArgs());
        }
    }
}
