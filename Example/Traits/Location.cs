using Agency;

namespace Example.Traits
{
    /// <summary>
    /// Trait to indicate a location
    /// </summary>
    class Location : Trait
    {
        public string Name { get; set; }

        public Location(string name)
        {
            Name = name;
        }
    }
}
