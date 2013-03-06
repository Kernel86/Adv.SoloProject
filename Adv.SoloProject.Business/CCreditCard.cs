using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CCreditCard
    {
        // Private Fields
        private int _iCreditCardId;
        private int _iCustomerId;
        private string _sCardName;
        private string _sCardNumber;
        private DateTime _dtCardExpiration;
        private int _iCreditCardTypeId;

        // Public Properties
        public int CreditCardId
        {
            get { return _iCreditCardId; }
            set { _iCreditCardId = value; }
        }

        public int CustomerId
        {
            get { return _iCustomerId; }
            set { _iCustomerId = value; }
        }

        public string CardName
        {
            get { return _sCardName; }
            set { _sCardName = value; }
        }

        public string CardNumber
        {
            get { return _sCardNumber; }
            set { _sCardNumber = value; }
        }

        public DateTime CardExpiration
        {
            get { return _dtCardExpiration; }
            set { _dtCardExpiration = value; }
        }

        public int CreditCardTypeId
        {
            get { return _iCreditCardTypeId; }
            set { _iCreditCardTypeId = value; }
        }

        // Public Methods
    }
}
