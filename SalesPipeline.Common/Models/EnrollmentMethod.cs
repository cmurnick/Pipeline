using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Models
{
    public class EnrollmentMethod
    {
        #region Constructors

        public EnrollmentMethod() { }

        #endregion

        #region Public Methods

        public int EnrollmentMethodId { get; set; }
        public string EnrollmentMethodType { get; set; }

        #endregion
    }
}
