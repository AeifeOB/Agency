using Agency;

namespace Test
{
    /// <summary>
    /// Class to provide an Asset for testing.
    /// </summary>
    class TestAsset : Asset
    {
        public int Id { get; set; }

        /// <summary>
        /// Constructor for TestAsset class.
        /// </summary>
        /// <param name="id"></param>
        public TestAsset(int id)
        {
            Id = id;
        }
    }
}
