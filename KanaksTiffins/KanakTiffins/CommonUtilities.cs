using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KanakTiffins
{
    class CommonUtilities
    {
        public static KanakTiffinsEntities db = new KanakTiffinsEntities();

        /// <summary>
        /// Based on the changes made/not made to the current bill being displayed, updates the Customer's dues.
        /// </summary>
        /// <param name="customerId">The customerId of the Customer whose dues have to be recalculated.</param>
        public static void updateCustomerDues(int customerId)
        {
            Int32 totalPayableAmount;
            try
            {
                totalPayableAmount = db.MonthlyBills.Where(x => x.CustomerId == customerId).Sum(x => x.LunchAmount + x.DinnerAmount - x.DailyPayment);
            }
            catch (Exception ex)
            {
                totalPayableAmount = 0;
            }

            Int32 totalPaidAmount;
            try
            {
                totalPaidAmount = db.CustomerPaymentHistories.Where(x => x.CustomerId == customerId).Sum(x => x.PaidAmount);
            }
            catch (Exception ex)
            {
                totalPaidAmount = 0;
            }

            Int32 dabbawalaCharges;
            try
            {
                dabbawalaCharges = db.ExtraCharges.Where(x => x.CustomerId == customerId).Sum(x => x.DabbawalaCharges);
            }
            catch (Exception ex)
            {
                dabbawalaCharges = 0;
            }

            Int32 deliveryCharges;
            try
            {
                deliveryCharges = db.ExtraCharges.Where(x => x.CustomerId == customerId).Sum(x => x.DeliveryCharges);
            }
            catch (Exception ex)
            {
                deliveryCharges = 0;
            }

            Int32 initialBalance = db.CustomerDetails.Where(x => x.CustomerId == customerId && x.isDeleted.Equals("N")).First().InitialBalance;

            Int32 totalDueAmount = totalPayableAmount + dabbawalaCharges + deliveryCharges + initialBalance - totalPaidAmount;

            //Put values in CustomerDues tables
            CustomerDue updatedDues = db.CustomerDues.Where(x => x.CustomerId == customerId).FirstOrDefault();

            if (updatedDues == null)
                updatedDues = new CustomerDue();

            updatedDues.CustomerId = customerId;
            if (totalDueAmount < 0)
            {
                updatedDues.CarryforwardAmount = -1 * totalDueAmount;
                updatedDues.DueAmount = 0;
            }
            else
            {
                updatedDues.DueAmount = totalDueAmount;
                updatedDues.CarryforwardAmount = 0;
            }

            if (db.CustomerDues.Where(x => x.CustomerId == customerId).Count() == 0)
            {
                db.CustomerDues.AddObject(updatedDues);
            }

            db.SaveChanges();
        }
    }
}
