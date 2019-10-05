# .net-mvc-5-stripe-sca
Our Goal is to implement stripe subscription model with  Strong customer authentication and payment intent APi in .net mvc 5 project.

As you all know all credit card transaction should be user secure according to the new europian law.

I am using payment intent api 

var subscriptionOptions = new SubscriptionCreateOptions()
            {
                PlanId = model.PlanId,
                CustomerId = customer.Id,
                TrialFromPlan = false,
                Expand = new List<string> { "latest_invoice.payment_intent", "pending_setup_intent" },
            };
            
we have to expand stripe subscription object to latest_invoice.payment_intent to check if any action required so that we can reidrect user to action required page
