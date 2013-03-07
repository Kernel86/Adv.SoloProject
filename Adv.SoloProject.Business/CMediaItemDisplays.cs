using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMediaItemDisplays
    {
                // Private Fields
        private List<CMediaItemDisplay> _glItems;

        // Public Properties
        public List<CMediaItemDisplay> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CMediaItemDisplay this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CMediaItemDisplays()
        {
            _glItems = new List<CMediaItemDisplay>();
        }

        // Events
        public event EventHandler MediaItemDisplaysChanged;

        // Public Methods
        public void Add(CMediaItemDisplay oItem)
        {
            _glItems.Add(oItem);
            if (MediaItemDisplaysChanged != null)
                MediaItemDisplaysChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (MediaItemDisplaysChanged != null)
                MediaItemDisplaysChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select MediaItemDisplays using LINQ
            var otblMediaItemDisplays = from c in oDc.SP_GetMediaItemDisplay() select c;

            // Fill generic list of MediaItemDisplays
            foreach (SP_GetMediaItemDisplayResult otblMediaItemDisplay in otblMediaItemDisplays)
            {
                CMediaItemDisplay oMediaItemDisplay = new CMediaItemDisplay(otblMediaItemDisplay);
                _glItems.Add(oMediaItemDisplay);
            }

            oDc = null;
        }
    }
}
