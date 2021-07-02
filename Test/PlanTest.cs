using Agency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    /// <summary>
    /// Class to test Plans in the Agency framework.
    /// </summary>
    [TestClass]
    public class PlanTest
    {
        /// <summary>
        /// Method to test the implementation of the Execute method provided by the Plan class.
        /// </summary>
        [TestMethod]
        public void PlanExecution()
        {
            Plan plan = new();
            Asset assetZero = new TestAsset(0);
            Asset assetOne = new TestAsset(1);

            List<Asset> outputAssetList = new()
            {
                assetOne,
                assetZero
            };

            Action actionZero = new TestAction();
            actionZero.Outputs.Add(assetZero);
            plan.Actions.Add(actionZero);

            Action actionOne = new TestAction();
            actionOne.Outputs.Add(assetOne);
            plan.Actions.Add(actionOne);

            List<Asset> resultAssetList = new();
            plan.Execute(resultAssetList);

            Assert.AreEqual(outputAssetList[0], resultAssetList[0]);
            Assert.AreEqual(outputAssetList[1], resultAssetList[1]);
            Assert.AreEqual(2, resultAssetList.Count);
        }
    }
}
