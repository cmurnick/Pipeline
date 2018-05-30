using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Models
{
    public class Classification
    {
        #region Constructors

        public Classification()
        {
        }

        #endregion

        #region Public Properties

        public int ClassificationId { get; set; }
        public string ClassificationName { get; set; }

        #endregion
    }
}
