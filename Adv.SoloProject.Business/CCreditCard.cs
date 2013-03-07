using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

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

        // Constructors
        public CCreditCard()
        {

        }

        public CCreditCard(tblCreditCard otblCreditCard)
        {
            _iCreditCardId = otblCreditCard.CreditCard_Id;
            _iCustomerId = otblCreditCard.Customer_Id;
            _sCardName = otblCreditCard.CardName;
            _sCardNumber = otblCreditCard.CardNumber;
            _dtCardExpiration = otblCreditCard.CardExpiration;
            _iCreditCardTypeId = otblCreditCard.CreditCardType_Id;
        }

        public CCreditCard(string sNew)
        {
            _iCreditCardId = 0;
            _iCustomerId = 0;
            _sCardName = "";
            _sCardNumber = sNew;
            _dtCardExpiration = DateTime.Now;
            _iCreditCardTypeId = 0;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblCreditCard otblCreditCard = new tblCreditCard();

                otblCreditCard.CreditCard_Id = CreditCardId;
                otblCreditCard.Customer_Id = CustomerId;
                otblCreditCard.CardName = CardName;
                otblCreditCard.CardNumber = CardNumber;
                otblCreditCard.CardExpiration = CardExpiration;
                otblCreditCard.CreditCardType_Id = CreditCardTypeId;

                oDc.tblCreditCards.InsertOnSubmit(otblCreditCard);
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

                tblCreditCard otblCreditCard = (from c in oDc.tblCreditCards
                                            where c.CreditCard_Id == CreditCardId
                                            select c).FirstOrDefault();

                otblCreditCard.CardName = CardName;
                otblCreditCard.CardNumber = CardNumber;
                otblCreditCard.CardExpiration = CardExpiration;
                otblCreditCard.CreditCardType_Id = CreditCardTypeId;

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

                tblCreditCard otblCreditCard = (from c in oDc.tblCreditCards where c.CreditCard_Id == CreditCardId select c).FirstOrDefault();

                oDc.tblCreditCards.DeleteOnSubmit(otblCreditCard);
                oDc.SubmitChanges();

                otblCreditCard = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
