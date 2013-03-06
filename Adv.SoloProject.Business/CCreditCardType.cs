using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CCreditCardType
    {
        // Private Fields
        private int _iCreditCardTypeId;
        private string _sDescription;

        // Public Properties
        public int CreditCardTypeId
        {
            get { return _iCreditCardTypeId; }
            set { _iCreditCardTypeId = value; }
        }

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        // Public Methods
    }
}
