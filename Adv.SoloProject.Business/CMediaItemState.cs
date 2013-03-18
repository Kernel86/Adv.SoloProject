using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMediaItemState
    {
        // Private Fields
        private int _iMediaItemStateId;
        private string _sDescription;

        // Public Properties
        public int MediaItemStateId
        {
            get { return _iMediaItemStateId; }
            set { _iMediaItemStateId = value; }
        }

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        // Constructors
        public CMediaItemState()
        {

        }

        public CMediaItemState(tblMediaItemState otblMediaItemState)
        {
            _iMediaItemStateId = otblMediaItemState.MediaItemState_Id;
            _sDescription = otblMediaItemState.Description;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblMediaItemState otblMediaItemState = new tblMediaItemState();

                otblMediaItemState.MediaItemState_Id = MediaItemStateId;
                otblMediaItemState.Description = Description;

                oDc.tblMediaItemStates.InsertOnSubmit(otblMediaItemState);
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

                tblMediaItemState otblMediaItemState = (from c in oDc.tblMediaItemStates
                                            where c.MediaItemState_Id == MediaItemStateId
                                            select c).FirstOrDefault();

                otblMediaItemState.Description = Description;

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

                tblMediaItemState otblMediaItemState = (from c in oDc.tblMediaItemStates where c.MediaItemState_Id == MediaItemStateId select c).FirstOrDefault();

                oDc.tblMediaItemStates.DeleteOnSubmit(otblMediaItemState);
                oDc.SubmitChanges();

                otblMediaItemState = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
