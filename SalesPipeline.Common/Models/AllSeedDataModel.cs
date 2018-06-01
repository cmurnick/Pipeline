using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Models
{
    public class AllSeedDataModel
    {
        #region Constructors

        public AllSeedDataModel()
        {
            this.SalesExecs = new List<SalesExec>();
            this.Classifications = new List<Classification>();
            this.EnrollmentMethods = new List<EnrollmentMethod>();
            this.EnrollmentSystems = new List<EnrollmentSystem>();
            this.VBCarriers = new List<VbCarrier>();
        }

        #endregion

        #region Public Properties

        public List<SalesExec> SalesExecs { get; set; }
        public List<Classification> Classifications { get; set; }
        public List<EnrollmentMethod> EnrollmentMethods { get; set; }
        public List<EnrollmentSystem> EnrollmentSystems { get; set; }
        public List<VbCarrier> VBCarriers { get; set; }
        #endregion

      
    }
}
