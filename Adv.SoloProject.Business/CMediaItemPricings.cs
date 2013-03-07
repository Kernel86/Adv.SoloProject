using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

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
            if (MediaItemPricingsChanged != null)
                MediaItemPricingsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (MediaItemPricingsChanged != null)
                MediaItemPricingsChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select customers using LINQ
            var otblMediaItemPricings = from c in oDc.tblMediaItemPricings select c;

            // Fill generic list of customers
            foreach (tblMediaItemPricing otblMediaItemPricing in otblMediaItemPricings)
            {
                CMediaItemPricing oMediaItemPricing = new CMediaItemPricing(otblMediaItemPricing);
                _glItems.Add(oMediaItemPricing);
            }

            oDc = null;
        }
    }
}
