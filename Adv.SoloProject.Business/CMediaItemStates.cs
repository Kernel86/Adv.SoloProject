using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMediaItemStates
    {
        // Private Fields
        private List<CMediaItemState> _glItems;

        // Public Properties
        public List<CMediaItemState> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CMediaItemState this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CMediaItemStates()
        {
            _glItems = new List<CMediaItemState>();
        }

        // Events
        public event EventHandler MediaItemStatesChanged;

        // Public Methods
        public void Add(CMediaItemState oItem)
        {
            _glItems.Add(oItem);
            if (MediaItemStatesChanged != null)
                MediaItemStatesChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (MediaItemStatesChanged != null)
                MediaItemStatesChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select MediaItemStates using LINQ
            var otblMediaItemStates = from c in oDc.tblMediaItemStates orderby c.Description select c;

            // Fill generic list of MediaItemStates
            foreach (tblMediaItemState otblMediaItemState in otblMediaItemStates)
            {
                CMediaItemState oMediaItemState = new CMediaItemState(otblMediaItemState);
                _glItems.Add(oMediaItemState);
            }

            oDc = null;
        }
    }
}
