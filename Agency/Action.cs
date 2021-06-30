using System.Collections.Generic;

namespace Agency
{
    /// <summary>
    /// An abstract class to represent actions that can be done by an Actor in framework.
    /// </summary>
    public abstract class Action
    {
        public List<Asset> Inputs { get; set; }
        public List<Asset> Outputs { get; set; }

        /// <summary>
        /// The default implementation of the Execute method. This method allows an action to be executed. 
        /// The default implementation removes each asset required by the action (Inputs) from the list of 
        /// assets provided, and then adds each asset in the Outputs  variable to the provided list of assets.
        /// </summary>
        /// <param name="assets"></param>
        public virtual void Execute(List<Asset> assets)
        {
            foreach (Asset asset in this.Inputs)
            {
                assets.Remove(asset);
            }
            foreach (Asset asset in this.Outputs)
            {
                assets.Add(asset);
            }
        }

    }
}
