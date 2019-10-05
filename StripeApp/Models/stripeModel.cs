using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StripeApp.Models
{
    public class stripeModel
    {
       
        public string StripePublishableKey { get; set; }
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
        public string IntentSecretis { get; set; }
        public string IntentId { get; set; }
        public string fullName { get; set; }
        public string PlanId { get; set; }


    }
}