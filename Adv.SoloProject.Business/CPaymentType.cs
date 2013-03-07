using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CPaymentType
    {
        // Private Fields
        private int _iPaymentTypeId;
        private string _sDescription;

        // Public Properties
        public int PaymentTypeId
        {
            get { return _iPaymentTypeId; }
            set { _iPaymentTypeId = value; }
        }

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        // Constructors
        public CPaymentType()
        {

        }

        public CPaymentType(tblPaymentType otblPaymentType)
        {
            _iPaymentTypeId = otblPaymentType.PaymentType_Id;
            _sDescription = otblPaymentType.Description;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblPaymentType otblPaymentType = new tblPaymentType();

                otblPaymentType.PaymentType_Id = PaymentTypeId;
                otblPaymentType.Description = Description;

                oDc.tblPaymentTypes.InsertOnSubmit(otblPaymentType);
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

                tblPaymentType otblPaymentType = (from c in oDc.tblPaymentTypes
                                            where c.PaymentType_Id == PaymentTypeId
                                            select c).FirstOrDefault();

                otblPaymentType.Description = Description;

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

                tblPaymentType otblPaymentType = (from c in oDc.tblPaymentTypes where c.PaymentType_Id == PaymentTypeId select c).FirstOrDefault();

                oDc.tblPaymentTypes.DeleteOnSubmit(otblPaymentType);
                oDc.SubmitChanges();

                otblPaymentType = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
