using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Models
{
    public class Product
    {
        #region Constructors

        public Product()
        {

        }

        #endregion

        #region Public Properties

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
        #endregion
    }
}
