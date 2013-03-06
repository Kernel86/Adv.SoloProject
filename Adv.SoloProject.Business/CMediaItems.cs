using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CMediaItems
    {
        // Private Fields
        private List<CMediaItem> _glItems;

        // Public Properties
        public List<CMediaItem> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CMediaItem this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CMediaItems()
        {
            _glItems = new List<CMediaItem>();
        }

        // Events
        public event EventHandler MediaItemsChanged;

        // Public Methods
        public void Add(CMediaItem oItem)
        {
            _glItems.Add(oItem);
            if (!MediaItemsChanged.Equals(null))
                MediaItemsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (!MediaItemsChanged.Equals(null))
                MediaItemsChanged(this, new EventArgs());
        }
    }
}
