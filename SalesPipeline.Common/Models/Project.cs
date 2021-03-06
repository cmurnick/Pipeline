﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Models
{
    public class Project
    {
        #region Constructors

        public Project()
        {
            this.Products = new List<Product>();
        }

        #endregion

        #region Public Properties

        public int ProjectId { get; set; }
        public string CompanyName { get; set; }
        public int NumberEligible { get; set; }
        public int NumberInterview { get; set; }
        public string ClassificationName { get; set; }
        public int ClassificationId { get; set; }
        public bool New { get; set; }
        public string FirstName { get; set; }
        public int SalesExecId { get; set; }
        public string SystemName { get; set; }
        public int EnrollmentSystemId { get; set; }
        public string VbCarrierName { get; set; }
        public int VbCarrierId { get; set; }
        public DateTime StartDate { get; set; }


        public string StartDateDisplay
        {
            get { return this.StartDate.ToShortDateString(); }
        }

        public DateTime EndDate { get; set; }

        public string EndDateDisplay
        {
            get { return this.EndDate.ToShortDateString(); }
        }

        public string EnrollmentMethodType { get; set; }
        public int EnrollmentMethodId { get; set; }


        public List<Product> Products { get; set; }

        public string ProductNames
        {
            get { return this.getProductNames(this.Products); }
        }

        #endregion

        #region Private

        private string getProductNames(List<Product> products)
        {
            var sb = new StringBuilder();

            var comma = string.Empty;
            foreach (var product in products)
            {
                sb.AppendFormat("{0}{1}", comma, product.ProductName.Trim());
                comma = ", ";
            }

            return sb.ToString();
        }

        #endregion
    }

}
