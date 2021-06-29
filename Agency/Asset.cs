namespace Agency
{
    abstract class Asset
    {
    }

    class Money : Asset
    {
        public float amount { get; set; }

        public Money(float amount)
        {
            this.amount = amount;
        }
    }

    class Team : Asset
    {
        public int members { get; set; }
        public Team(int members)
        {
            this.members = members;
        }
    }
}
