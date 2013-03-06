using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CMediaItemPricings
    {
        // Private Fields
        private List<CMediaItemPricing> _glItems;

        // Public Properties
        public List<CMediaItemPricing> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CMediaItemPricing this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CMediaItemPricings()
        {
            _glItems = new List<CMediaItemPricing>();
        }

        // Events
        public event EventHandler MediaItemPricingsChanged;

        // Public Methods
        public void Add(CMediaItemPricing oItem)
        {
            _glItems.Add(oItem);
            if (!MediaItemPricingsChanged.Equals(null))
                MediaItemPricingsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (!MediaItemPricingsChanged.Equals(null))
                MediaItemPricingsChanged(this, new EventArgs());
        }
    }
}
