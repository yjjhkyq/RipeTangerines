using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Customers
{
    public class CustomerRegistrationResult
    {
        public IList<string> Errors { get; set; }

        public CustomerRegistrationResult()
        {
            this.Errors = new List<string>();
        }

        public bool Success
        {
            get { return this.Errors.Count == 0; }
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}
