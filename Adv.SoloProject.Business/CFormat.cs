using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        // Public Methods
    }
}
