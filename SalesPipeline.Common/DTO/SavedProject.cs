﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.DTO
{
    using Models;

    public class SavedProject
    {
        #region Public Properties

        public int ProjectId { get; set; }
        public string CompanyName { get; set; }
        public int NumberEligible { get; set; }
        public int NumberInterview { get; set; }
        public int ClassificationId { get; set; }
        public bool New { get; set; }
        public int SalesExecId { get; set; }
        public int EnrollmentSystemId { get; set; }
        public int VbCarrierId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EnrollmentMethodId { get; set; }

        #endregion
    }
}