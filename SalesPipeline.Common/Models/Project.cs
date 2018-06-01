using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Models
{
    public class Project
    {
        #region Constructors

        public Project()
        {
            this.Product = new List<Product>();
        }

        #endregion

        #region Public Properties

        public int ProjectId { get; set; }
        public string CompanyName { get; set; }
        public int NumberEligible { get; set; }
        public int NumberInterview { get; set; }
        public int ClassificationId { get; set; }
        public bool New { get; set; }
        public int SalesExecId { get; set; }
        public int EnrollmentSystemId { get; set; }
        public int VBCarrierId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EnrollmentMethodId { get; set; }


        public List<Product> Product { get; set; }

        #endregion
    }
}
