using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        // Public Methods
    }
}
