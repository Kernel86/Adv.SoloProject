using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMedias
    {
        // Private Fields
        private List<CMedia> _glItems;

        // Public Properties
        public List<CMedia> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CMedia this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CMedias()
        {
            _glItems = new List<CMedia>();
        }

        // Events
        public event EventHandler MediasChanged;

        // Public Methods
        public void Add(CMedia oItem)
        {
            _glItems.Add(oItem);
            if (MediasChanged != null)
                MediasChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (MediasChanged != null)
                MediasChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select customers using LINQ
            var otblMedias = from c in oDc.tblMedias select c;

            // Fill generic list of customers
            foreach (tblMedia otblMedia in otblMedias)
            {
                CMedia oMedia = new CMedia(otblMedia);
                _glItems.Add(oMedia);
            }

            oDc = null;
        }
    }
}
