using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CCreditCards
    {
        // Private Fields
        private List<CCreditCard> _glItems;

        // Public Properties
        public List<CCreditCard> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CCreditCard this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CCreditCards()
        {
            _glItems = new List<CCreditCard>();
        }

        // Events
        public event EventHandler CreditCardsChanged;

        // Public Methods
        public void Add(CCreditCard oItem)
        {
            _glItems.Add(oItem);
            if (!CreditCardsChanged.Equals(null))
                CreditCardsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (!CreditCardsChanged.Equals(null))
                CreditCardsChanged(this, new EventArgs());
        }
    }
}
