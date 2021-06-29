namespace Agency
{
    abstract class Asset
    {
    }

    class Money : Asset
    {
        public float Amount { get; set; }

        public Money(float amount)
        {
            this.Amount = amount;
        }
    }

    class Team : Asset
    {
        public int Members { get; set; }
        public Team(int members)
        {
            this.Members = members;
        }
    }
}
