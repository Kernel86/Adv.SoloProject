using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMedia
    {
        // Private Fields
        private int _iMediaId;
        private DateTime _dtReleaseDate;
        private string _sTitle;

        // Public Properties
        public int MediaId
        {
            get { return _iMediaId; }
            set { _iMediaId = value; }
        }

        public DateTime ReleaseDate
        {
            get { return _dtReleaseDate; }
            set { _dtReleaseDate = value; }
        }

        public string Title
        {
            get { return _sTitle; }
            set { _sTitle = value; }
        }

        // Constructors
        public CMedia()
        {

        }

        public CMedia(tblMedia otblMedia)
        {
            _iMediaId = otblMedia.Media_Id;
            _dtReleaseDate = (DateTime)otblMedia.ReleaseDate;
            _sTitle = otblMedia.Title;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblMedia otblMedia = new tblMedia();

                otblMedia.Media_Id = MediaId;
                otblMedia.ReleaseDate = ReleaseDate;
                otblMedia.Title = Title;

                oDc.tblMedias.InsertOnSubmit(otblMedia);
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

                tblMedia otblMedia = (from c in oDc.tblMedias
                                            where c.Media_Id == MediaId
                                            select c).FirstOrDefault();

                MediaId = otblMedia.Media_Id;
                ReleaseDate = (DateTime)otblMedia.ReleaseDate;
                Title = otblMedia.Title;

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

                tblMedia otblMedia = (from c in oDc.tblMedias where c.Media_Id == MediaId select c).FirstOrDefault();

                oDc.tblMedias.DeleteOnSubmit(otblMedia);
                oDc.SubmitChanges();

                otblMedia = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
