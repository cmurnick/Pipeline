using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPipeline.Common.Models
{
    public class ServiceReturn<T>
    {
        public ServiceReturn()
        {
            this.Messages = new List<Message>();
        }

        public bool Success { get; set; }

        public List<Message> Messages { get; set; }

        public T Data { get; set; }

        public long? ItemId { get; set; }
    }
}
