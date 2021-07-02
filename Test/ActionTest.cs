using Agency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    /// <summary>
    /// Class to test Actions in the Agency framework.
    /// </summary>
    [TestClass]
    public class ActionTest
    {
        /// <summary>
        /// Method to test the default constructor provided by the Asset abstract class.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor()
        {
            Action action = new TestAction();
            Assert.AreEqual(new List<Asset>().GetType(), action.Inputs.GetType());
            Assert.AreEqual(0, action.Inputs.Count);
            Assert.AreEqual(new List<Asset>().GetType(), action.Outputs.GetType());
            Assert.AreEqual(0, action.Outputs.Count);
        }

        /// <summary>
        /// Method to test the output of the default implementation of the Execute method provided by the Asset abstract class.
        /// </summary>
        [TestMethod]
        public void DefaultExecuteOutput()
        {
            Asset assetZero = new TestAsset(0);
            Asset assetOne = new TestAsset(1);

            List<Asset> IncorrectAssetList = new()
            {
                assetZero
            };

            List<Asset> outputAssetList = new()
            {
                assetOne
            };

            Action action = new TestAction();
            action.Outputs.Add(assetOne);

            List<Asset> resultAssetList = new();

            action.Execute(resultAssetList);

            Assert.AreNotEqual(IncorrectAssetList[0], resultAssetList[0]);
            Assert.AreEqual(outputAssetList[0], resultAssetList[0]);
        }

        // <summary>
        /// Method to test the input of the default implementation of the Execute method provided by the Asset abstract class.
        /// </summary>
        [TestMethod]
        public void DefaultExecuteInput()
        {
            Asset assetZero = new TestAsset(0);
            Asset assetOne = new TestAsset(1);

            List<Asset> outputAssetList = new()
            {
                assetZero
            };

            Action action = new TestAction();
            action.Inputs.Add(assetOne);

            List<Asset> resultAssetList = new()
            {
                assetZero,
                assetOne
            };

            action.Execute(resultAssetList);

            Assert.AreEqual(outputAssetList[0], resultAssetList[0]);
            try
            {
                var obj = resultAssetList[1];
                Assert.Fail("An exception should have been thrown");
            }
            catch (System.ArgumentOutOfRangeException ae)
            {
                Assert.AreEqual("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", ae.Message);
            }
            catch (System.Exception e)
            {
                Assert.Fail(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }
        }
    }
}
