using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adv.SoloProject.Business
{
    public class CRentalItem
    {
        // Private Fields
        private int _iRentalItemId;
        private int _iRentalId;
        private int _iMediaItemId;
        private DateTime _dtDueDate;

        // Public Properties
        public int RentalItemId
        {
            get { return _iRentalItemId; }
            set { _iRentalItemId = value; }
        }

        public int RentalId
        {
            get { return _iRentalId; }
            set { _iRentalId = value; }
        }

        public int MediaItemId
        {
            get { return _iMediaItemId; }
            set { _iMediaItemId = value; }
        }

        public DateTime DueDate
        {
            get { return _dtDueDate; }
            set { _dtDueDate = value; }
        }

        // Public Methods
    }
}
