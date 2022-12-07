using Agency;

namespace Example.Assets
{
    /// <summary>
    /// A class representing a financial asset in the framework. Inherits in Asset abstract class.
    /// </summary>
    class Money : Asset
    {
        public float Amount { get; set; }

        /// <summary>
        /// Constructor for the Money asset class.
        /// </summary>
        /// <param name="amount"></param>
        public Money(float amount)
        {
            this.Amount = amount;
        }
    }
}
