using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adv.SoloProject.Data;

namespace Adv.SoloProject.Business
{
    public class CMediaItem
    {
        // Private Fields
        private int _iMediaItemId;
        private DateTime _dtInventoryDate;
        private int _iMediaId;
        private int _iMediaItemStateId;
        private int _iMediaItemPricingId;
        private int _iFormatId;

        // Public Properties
        public int MediaItemId
        {
            get { return _iMediaItemId; }
            set { _iMediaItemId = value; }
        }

        public DateTime InventoryDate
        {
            get { return _dtInventoryDate; }
            set { _dtInventoryDate = value; }
        }

        public int MediaId
        {
            get { return _iMediaId; }
            set { _iMediaId = value; }
        }

        public int MediaItemStateId
        {
            get { return _iMediaItemStateId; }
            set { _iMediaItemStateId = value; }
        }

        public int MediaItemPricingId
        {
            get { return _iMediaItemPricingId; }
            set { _iMediaItemPricingId = value; }
        }

        public int FormatId
        {
            get { return _iFormatId; }
            set { _iFormatId = value; }
        }

        // Constructors
        public CMediaItem()
        {

        }

        public CMediaItem(tblMediaItem otblMediaItem)
        {
            _iMediaItemId = otblMediaItem.MediaItem_Id;
            _dtInventoryDate = (DateTime)otblMediaItem.InvetoryDate;
            _iMediaId = otblMediaItem.Media_Id;
            _iMediaItemStateId = otblMediaItem.MediaItemState_Id;
            _iMediaItemPricingId = otblMediaItem.MediaItemPricing_Id;
            _iFormatId = otblMediaItem.Format_Id;
        }

        // Public Methods
        public void Insert()
        {
            try
            {
                MediaVaultDataContext oDc = new MediaVaultDataContext();

                tblMediaItem otblMediaItem = new tblMediaItem();

                otblMediaItem.MediaItem_Id = MediaItemId;
                otblMediaItem.InvetoryDate = (DateTime)InventoryDate;
                otblMediaItem.Media_Id = MediaId;
                otblMediaItem.MediaItemState_Id = MediaItemStateId;
                otblMediaItem.MediaItemPricing_Id = MediaItemPricingId;
                otblMediaItem.Format_Id = FormatId;

                oDc.tblMediaItems.InsertOnSubmit(otblMediaItem);
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

                tblMediaItem otblMediaItem = (from c in oDc.tblMediaItems
                                            where c.MediaItem_Id == MediaItemId
                                            select c).FirstOrDefault();

                otblMediaItem.InvetoryDate = (DateTime)InventoryDate;
                otblMediaItem.Media_Id = MediaId;
                otblMediaItem.MediaItemState_Id = MediaItemStateId;
                otblMediaItem.MediaItemPricing_Id = MediaItemPricingId;
                otblMediaItem.Format_Id = FormatId;

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

                tblMediaItem otblMediaItem = (from c in oDc.tblMediaItems where c.MediaItem_Id == MediaItemId select c).FirstOrDefault();

                oDc.tblMediaItems.DeleteOnSubmit(otblMediaItem);
                oDc.SubmitChanges();

                otblMediaItem = null;
                oDc = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
