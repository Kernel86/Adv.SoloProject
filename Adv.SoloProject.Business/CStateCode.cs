using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CStateCode
    {
        // Private Fields
        private int _iStateCodeId;
        private string _sCode;
        private string _sDescription;

        // Public Properties
        public int StateCodeId
        {
          get { return _iStateCodeId; }
          set { _iStateCodeId = value; }
        }

        public string Code
        {
          get { return _sCode; }
          set { _sCode = value; }
        }

        public string Description
        {
          get { return _sDescription; }
          set { _sDescription = value; }
        }

        // Constructors
        public CStateCode()
        {

        }

        public CStateCode(tblStateCode otblStateCode)
        {
            _iStateCodeId = otblStateCode.State_Id;
            _sCode = otblStateCode.Code;
            _sDescription = otblStateCode.Description;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblStateCode otblStateCode = new tblStateCode();

                otblStateCode.State_Id = StateCodeId;
                otblStateCode.Code = Code;
                otblStateCode.Description = Description;

                oDc.tblStateCodes.InsertOnSubmit(otblStateCode);
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

                tblStateCode otblStateCode = (from c in oDc.tblStateCodes
                                            where c.State_Id == StateCodeId
                                            select c).FirstOrDefault();

                otblStateCode.Code = Code;
                otblStateCode.Description = Description;

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

                tblStateCode otblStateCode = (from c in oDc.tblStateCodes where c.State_Id == StateCodeId select c).FirstOrDefault();

                oDc.tblStateCodes.DeleteOnSubmit(otblStateCode);
                oDc.SubmitChanges();

                otblStateCode = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
