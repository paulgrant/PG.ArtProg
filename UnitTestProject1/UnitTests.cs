using Microsoft.VisualStudio.TestTools.UnitTesting;
using PG.AP.Library;

namespace PG.AP.Test
{
    [TestClass]
    public class UnitTests
    {

        ArtProgObject artProg;

        [TestInitialize]
        public void SetUp()
        {
            artProg = new ArtProgObject();
        }

        [TestMethod]
        public void TestWithNullArray()
        {
            var returnIntArray = artProg.findTheMissing(null);
            Assert.IsNull(returnIntArray);
        }

        [TestMethod]
        public void TestWithEmptyArray()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { });
            Assert.IsNull(returnIntArray);
        }

        [TestMethod]
        public void TestWithNoneMissingInArray()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { 1,2,3,4,5 });
            Assert.IsNull(returnIntArray);
        }

        [TestMethod]
        public void TestWithOneMissingInArray()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { 1, 2, 4, 5 });
            Assert.IsNotNull(returnIntArray);
            Assert.IsTrue(returnIntArray.Length.Equals(1), "Length is not as expected:1, actual:" + returnIntArray.Length);
            Assert.IsTrue(returnIntArray[0] == 3);
        }

        [TestMethod]
        public void TestWithTwoMissingInArray()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { 1, 3, 5, 9, 11, 13, 17 });
            Assert.IsNotNull(returnIntArray);
            Assert.IsTrue(returnIntArray.Length.Equals(2), "Length is not as expected:2, actual:" + returnIntArray.Length);
            Assert.IsTrue(returnIntArray[0] == 7);
            Assert.IsTrue(returnIntArray[1] == 15);
        }

        [TestMethod]
        public void TestWithThreeMissingInArray()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { 1, 3, 5, 9, 11, 13, 17, 19, 21, 25 });
            Assert.IsNotNull(returnIntArray);
            Assert.IsTrue(returnIntArray.Length.Equals(3), "Length is not as expected:3, actual:" + returnIntArray.Length);
            Assert.IsTrue(returnIntArray[0] == 7);
            Assert.IsTrue(returnIntArray[1] == 15);
            Assert.IsTrue(returnIntArray[2] == 23);
        }

        [TestMethod]
        public void TestWithTwoSequentiallyMissingInArray()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { 1, 2, 5, 6, 7 });
            Assert.IsNotNull(returnIntArray);
            Assert.IsTrue(returnIntArray.Length.Equals(2), "Length is not as expected:2, actual:" + returnIntArray.Length);
            Assert.IsTrue(returnIntArray[0] == 3);
            Assert.IsTrue(returnIntArray[1] == 4);
        }

        [TestMethod]
        public void TestWithOneMissingInArrayReversed()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { 9, 6, 3, 0, -6, -9, -12 });
            Assert.IsNotNull(returnIntArray);
            Assert.IsTrue(returnIntArray.Length.Equals(1), "Length is not as expected:1, actual:" + returnIntArray.Length);
            Assert.IsTrue(returnIntArray[0] == -3);
        }

        [TestMethod]
        public void TestWithOneMissingInArrayStartingNegative()
        {
            var returnIntArray = artProg.findTheMissing(new int[] { -9, -6, -3, 0, 6, 9, 12 });
            Assert.IsNotNull(returnIntArray);
            Assert.IsTrue(returnIntArray.Length.Equals(1), "Length is not as expected:1, actual:" + returnIntArray.Length);
            Assert.IsTrue(returnIntArray[0] == 3);
        }

        [TestCleanup]
        public void TearDown()
        {
            artProg = null;
        }
    }
}
