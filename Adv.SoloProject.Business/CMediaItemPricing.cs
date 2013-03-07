using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMediaItemPricing
    {
        // Private Fields
        private int _iMediaItemPricingId;
        private string _sDescription;
        private decimal _dPrice;
        private int _iLength;

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

        public int Length
        {
            get { return _iLength; }
            set { _iLength = value; }
        }

        // Constructors
        public CMediaItemPricing()
        {

        }

        public CMediaItemPricing(tblMediaItemPricing otblMediaItemPricing)
        {
            _iMediaItemPricingId = otblMediaItemPricing.MediaItemPricing_Id;
            _sDescription = otblMediaItemPricing.Description;
            _dPrice = otblMediaItemPricing.Price;
            _iLength = otblMediaItemPricing.Length;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblMediaItemPricing otblMediaItemPricing = new tblMediaItemPricing();

                otblMediaItemPricing.MediaItemPricing_Id = MediaItemPricingId;
                otblMediaItemPricing.Description = Description;
                otblMediaItemPricing.Price = Price;
                otblMediaItemPricing.Length = Length;

                oDc.tblMediaItemPricings.InsertOnSubmit(otblMediaItemPricing);
                oDc.SubmitChanges();
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblMediaItemPricing otblMediaItemPricing = (from c in oDc.tblMediaItemPricings
                                            where c.MediaItemPricing_Id == MediaItemPricingId
                                            select c).FirstOrDefault();

                otblMediaItemPricing.Description = Description;
                otblMediaItemPricing.Price = Price;
                otblMediaItemPricing.Length = Length;

                oDc.SubmitChanges();
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblMediaItemPricing otblMediaItemPricing = (from c in oDc.tblMediaItemPricings where c.MediaItemPricing_Id == MediaItemPricingId select c).FirstOrDefault();

                oDc.tblMediaItemPricings.DeleteOnSubmit(otblMediaItemPricing);
                oDc.SubmitChanges();

                otblMediaItemPricing = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
