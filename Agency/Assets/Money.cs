namespace Agency
{
    class Money : Asset
    {
        public float Amount { get; set; }

        public Money(float amount)
        {
            this.Amount = amount;
        }

        public bool Meets(Money asset)
        {
            if (this.Amount <= asset.Amount)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
