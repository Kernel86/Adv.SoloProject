using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CMediaItemPricing
    {
        // Private Fields
        private int _iMediaItemPricingId;
        private string _sDescription;
        private decimal _dPrice;

        // Public Properties
        public int MediaItemPricingId
        {
            get { return _iMediaItemPricingId; }
            set { _iMediaItemPricingId = value; }
        }

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        public decimal Price
        {
            get { return _dPrice; }
            set { _dPrice = value; }
        }

        // Public Methods
    }
}
