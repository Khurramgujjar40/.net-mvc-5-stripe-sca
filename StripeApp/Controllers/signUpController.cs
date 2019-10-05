using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;
using StripeApp.Models;

namespace StripeApp.Controllers
{
    public class signUpController : Controller
    {
        // GET: signUp
        public ActionResult Index()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new stripeModel() { StripePublishableKey = stripePublishableKey, PlanId = "basicMonthly", PlanCost = "100", PaymentFormHidden = true };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(stripeModel  model)
        {
            var customers = new CustomerService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = model.StripeEmail,
                Source = model.StripeToken,
                Name = model.fullName,

            });
            var subscriptionOptions = new SubscriptionCreateOptions()
            {
                PlanId = model.PlanId,
                CustomerId = customer.Id,
                TrialFromPlan = false,
                Expand = new List<string> { "latest_invoice.payment_intent", "pending_setup_intent" },
            };

            var subscriptionService = new SubscriptionService();
            Subscription subscription = subscriptionService.Create(subscriptionOptions);


            if (subscription.LatestInvoice.PaymentIntent.NextAction != null)
            {
                if (subscription.LatestInvoice.PaymentIntent.Status == "requires_action")
                {
                    
                    model.IntentSecretis = subscription.LatestInvoice.PaymentIntent.ClientSecret;
                    
                }



            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



            return View(model);
        }


    }
}