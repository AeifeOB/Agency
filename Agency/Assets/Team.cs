namespace Agency
{
    class Team : Asset
    {
        public int Members { get; set; }

        public Team(int members)
        {
            this.Members = members;
        }

        public bool Meets(Team asset)
        {
            if (this.Members <= asset.Members)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
