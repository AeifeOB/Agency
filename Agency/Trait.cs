namespace Agency
{
    /// <summary>
    /// An abstract class for all Traits to inherit from.
    /// </summary>
    public abstract class Trait
    {
        public Need need { get; set; }

        public Trait() {
            need = null;
        }
    }
}
