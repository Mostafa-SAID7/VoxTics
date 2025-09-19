using System;
using System.Threading.Tasks;
using VoxTics.Models.Enums;

namespace VoxTics.Helpers
{
    public static class PaymentHelper
    {
        /// <summary>
        /// Validates that a selected payment method is allowed.
        /// </summary>
        public static bool IsValidPaymentMethod(PaymentMethod method)
        {
            return method != PaymentMethod.Undefined;
        }

        /// <summary>
        /// Calculates the total payable amount including fees (if any).
        /// </summary>
        public static decimal CalculateTotalAmount(decimal baseAmount, decimal processingFee = 0)
        {
            return baseAmount + processingFee;
        }

        /// <summary>
        /// Simulates processing a payment.
        /// In real application, integrate with a payment gateway.
        /// </summary>
        public static async Task<bool> ProcessPaymentAsync(decimal amount, PaymentMethod method, string? transactionId = null)
        {
            if (!IsValidPaymentMethod(method))
                throw new ArgumentException("Invalid payment method.");

            // Simulate async payment processing
            await Task.Delay(500); // simulate API call

            // For real integration, replace this with gateway logic
            Console.WriteLine($"Processed payment of {amount:C} using {method}. Transaction ID: {transactionId ?? Guid.NewGuid().ToString()}");

            // Return true to indicate success
            return true;
        }

        /// <summary>
        /// Refund a payment.
        /// </summary>
        public static async Task<bool> RefundPaymentAsync(decimal amount, PaymentMethod method, string transactionId)
        {
            // Simulate async refund
            await Task.Delay(500);
            Console.WriteLine($"Refunded {amount:C} for transaction {transactionId} via {method}");
            return true;
        }
    }
}
