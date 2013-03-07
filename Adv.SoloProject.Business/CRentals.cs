using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CRentals
    {
        // Private Fields
        private List<CRental> _glItems;

        // Public Properties
        public List<CRental> Items
        {
            get { return _glItems; }
            set { _glItems = value; }
        }

        public int Count
        {
            get { return _glItems.Count; }
        }

        public CRental this[int index]
        {
            get { return _glItems[index]; }
            set { _glItems[index] = value; }
        }

        // Public Constructors
        public CRentals()
        {
            _glItems = new List<CRental>();
        }

        // Events
        public event EventHandler RentalsChanged;

        // Public Methods
        public void Add(CRental oItem)
        {
            _glItems.Add(oItem);
            if (!RentalsChanged.Equals(null))
                RentalsChanged(this, new EventArgs());
        }

        public void RemoveAt(int iIndex)
        {
            _glItems.RemoveAt(iIndex);
            if (!RentalsChanged.Equals(null))
                RentalsChanged(this, new EventArgs());
        }

        public void Load()
        {
            MediaVaultDataContext oDc = new MediaVaultDataContext();

            // Select Rentals using LINQ
            var otblRentals = from c in oDc.tblRentals select c;

            // Fill generic list of Rentals
            foreach (tblRental otblRental in otblRentals)
            {
                CRental oRental = new CRental(otblRental);
                _glItems.Add(oRental);
            }

            oDc = null;
        }
    }
}
