using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CRental
    {
        // Private Fields
        private int _iRentalId;
        private int _iCustomerId;
        private int _iPaymentTypeId;
        private int _iCreditCardId;
        private decimal _dTransactionAmount;

        // Public Properties
        public int RentalId
        {
            get { return _iRentalId; }
            set { _iRentalId = value; }
        }

        public int CustomerId
        {
            get { return _iCustomerId; }
            set { _iCustomerId = value; }
        }

        public int PaymentTypeId
        {
            get { return _iPaymentTypeId; }
            set { _iPaymentTypeId = value; }
        }

        public int CreditCardId
        {
            get { return _iCreditCardId; }
            set { _iCreditCardId = value; }
        }

        public decimal TransactionAmount
        {
            get { return _dTransactionAmount; }
            set { _dTransactionAmount = value; }
        }

        // Constructors
        public CRental()
        {

        }

        public CRental(tblRental otblRental)
        {
            _iRentalId = otblRental.Rental_Id;
            _iCustomerId = otblRental.Customer_Id;
            _iPaymentTypeId = otblRental.PaymentType_Id;
            _iCreditCardId = (int)otblRental.CreditCard_Id;
            _dTransactionAmount = otblRental.TransactionAmount;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblRental otblRental = new tblRental();

                //otblRental.Rental_Id = RentalId;
                //otblRental.InvetoryDate = (DateTime)InventoryDate;
                //otblRental.Media_Id = MediaId;
                //otblRental.RentalState_Id = RentalStateId;
                //otblRental.RentalPricing_Id = RentalPricingId;
                //otblRental.Format_Id = FormatId;

                oDc.tblRentals.InsertOnSubmit(otblRental);
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

                tblRental otblRental = (from c in oDc.tblRentals
                                            where c.Rental_Id == RentalId
                                            select c).FirstOrDefault();

                //otblRental.InvetoryDate = (DateTime)InventoryDate;
                //otblRental.Media_Id = MediaId;
                //otblRental.RentalState_Id = RentalStateId;
                //otblRental.RentalPricing_Id = RentalPricingId;
                //otblRental.Format_Id = FormatId;

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

                tblRental otblRental = (from c in oDc.tblRentals where c.Rental_Id == RentalId select c).FirstOrDefault();

                oDc.tblRentals.DeleteOnSubmit(otblRental);
                oDc.SubmitChanges();

                otblRental = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
