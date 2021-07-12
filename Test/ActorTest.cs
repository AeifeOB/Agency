using Agency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    /// <summary>
    /// Class to test Actors in the Agency framework.
    /// </summary>
    [TestClass]
    public class ActorTest
    {

        // <summary>
        /// Method to test the Think method of the Actor class.
        /// </summary>
        [TestMethod]
        public void Think()
        {
            Actor testActor = new();

            Asset testAsset = new TestAsset(1);
            Action testGoal = new TestGoal();
            testGoal.InputAssets.Add(testAsset);
            testActor.Goals.Add(testGoal);

            Action testAction = new TestAction();
            testAction.OutputAssets.Add(testAsset);
            testActor.AvailableActions.Add(testAction);

            testActor.Think();

            Assert.AreEqual(2, testActor.CurrentPlan.Actions.Count);
            Assert.AreEqual(testGoal, testActor.CurrentPlan.Actions[0]);
            Assert.AreEqual(testAction, testActor.CurrentPlan.Actions[1]);
        }

        // <summary>
        /// Method to test the FindRequiredAssets method of the Actor class.
        /// </summary>
        [TestMethod]
        public void FindRequiredAssets()
        {
            // Positive testing
            Actor testActor = new();
            Asset testAsset = new TestAsset(1);
            testActor.AvailableAssets.Add(testAsset);

            Action testAction = new TestAction();
            testAction.InputAssets.Add(testAsset);
            List<Asset> testResults = testActor.FindRequiredAssets(testAction);

            Assert.AreEqual(0, testResults.Count);

            // Negative tesing
            Actor negativeTestActor = new();
            List<Asset> negativeTestResults = negativeTestActor.FindRequiredAssets(testAction);

            Assert.AreEqual(1, negativeTestResults.Count);
            Assert.AreEqual(testAsset, negativeTestResults[0]);
        }
    }
}
