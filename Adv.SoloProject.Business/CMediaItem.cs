using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CMediaItem
    {
        // Private Fields
        private int _iMediaItemId;
        private DateTime _dtInventoryDate;
        private int _iMediaId;
        private int _iMediaItemStateId;
        private int _iMediaItemPricingId;
        private int _iFormatId;

        // Public Properties
        public int MediaItemId
        {
            get { return _iMediaItemId; }
            set { _iMediaItemId = value; }
        }

        public DateTime InventoryDate
        {
            get { return _dtInventoryDate; }
            set { _dtInventoryDate = value; }
        }

        public int MediaId
        {
            get { return _iMediaId; }
            set { _iMediaId = value; }
        }

        public int MediaItemStateId
        {
            get { return _iMediaItemStateId; }
            set { _iMediaItemStateId = value; }
        }

        public int MediaItemPricingId
        {
            get { return _iMediaItemPricingId; }
            set { _iMediaItemPricingId = value; }
        }

        public int FormatId
        {
            get { return _iFormatId; }
            set { _iFormatId = value; }
        }

        // Public Methods
    }
}
