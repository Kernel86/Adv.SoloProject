using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMediaItemDisplay
    {
        // Private Fields
        private int _iMediaItemId;
        private int _iMediaItemPricingId;
        private string _sBarcode;
        private string _sTitle;
        private DateTime _dtReleaseDate;
        private string _sFormat;
        private DateTime _dtInventoryDate;
        private string _sInventory;
        private string _sPricing;
        private decimal _dPrice;
        private int _iLength;

        // Public Properties
        public int MediaItemId
        {
            get { return _iMediaItemId; }
            set { _iMediaItemId = value; }
        }

        public int MediaItemPricingId
        {
            get { return _iMediaItemPricingId; }
            set { _iMediaItemPricingId = value; }
        }

        public string Barcode
        {
            get { return _sBarcode; }
            set { _sBarcode = value; }
        }

        public string Title
        {
            get { return _sTitle; }
            set { _sTitle = value; }
        }

        public DateTime ReleaseDate
        {
            get { return _dtReleaseDate; }
            set { _dtReleaseDate = value; }
        }

        public string Format
        {
            get { return _sFormat; }
            set { _sFormat = value; }
        }

        public DateTime InventoryDate
        {
            get { return _dtInventoryDate; }
            set { _dtInventoryDate = value; }
        }

        public string Inventory
        {
            get { return _sInventory; }
            set { _sInventory = value; }
        }

        public string Pricing
        {
            get { return _sPricing; }
            set { _sPricing = value; }
        }

        public decimal Price
        {
            get { return _dPrice; }
            set { _dPrice = value; }
        }

        public int Length
        {
            get { return _iLength; }
            set { _iLength = value; }
        }

        // Constructors
        public CMediaItemDisplay()
        {

        }

        public CMediaItemDisplay(SP_GetMediaItemDisplayResult otblMediaItemDisplay)
        {
            _iMediaItemId = otblMediaItemDisplay.MediaItem_Id;
            _iMediaItemPricingId = otblMediaItemDisplay.MediaItemPricing_Id;
            _sBarcode = otblMediaItemDisplay.Barcode;
            _sTitle = otblMediaItemDisplay.Title;
            _dtReleaseDate = (DateTime)otblMediaItemDisplay.ReleaseDate;
            _sFormat = otblMediaItemDisplay.Format;
            _dtInventoryDate = (DateTime)otblMediaItemDisplay.InvetoryDate;
            _sInventory = otblMediaItemDisplay.Inventory;
            _sPricing = otblMediaItemDisplay.Pricing;
            _dPrice = otblMediaItemDisplay.Price;
            _iLength = otblMediaItemDisplay.Length;
        }

        // Public Methods
    }
}
