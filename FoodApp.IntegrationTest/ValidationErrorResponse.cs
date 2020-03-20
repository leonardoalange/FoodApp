using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.IntegrationTest
{
   public class ValidationErrorResponse
    {
        public string _Key { get; set; }
        public string _Message { get; set; }

        public ValidationErrorResponse(string key, string message)
        {
            _Key = key;
            _Message = message;
        }
    }
}
