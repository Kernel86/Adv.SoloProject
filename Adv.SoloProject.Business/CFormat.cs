using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CFormat
    {
        // Private Fields
        private int _iFormatId;
        private string _sDescription;

        // Public Properties
        public int FormatId
        {
            get { return _iFormatId; }
            set { _iFormatId = value; }
        }

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        // Constructors
        public CFormat()
        {

        }

        public CFormat(tblFormat otblFormat)
        {
            _iFormatId = otblFormat.Format_Id;
            _sDescription = otblFormat.Description;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblFormat otblFormat = new tblFormat();

                otblFormat.Format_Id = FormatId;
                otblFormat.Description = Description;

                oDc.tblFormats.InsertOnSubmit(otblFormat);
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

                tblFormat otblFormat = (from c in oDc.tblFormats
                                            where c.Format_Id == FormatId
                                            select c).FirstOrDefault();

                otblFormat.Description = Description;

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

                tblFormat otblFormat = (from c in oDc.tblFormats where c.Format_Id == FormatId select c).FirstOrDefault();

                oDc.tblFormats.DeleteOnSubmit(otblFormat);
                oDc.SubmitChanges();

                otblFormat = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
