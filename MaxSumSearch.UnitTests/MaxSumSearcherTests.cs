using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using MaxSumSearch.Application;


namespace MaxSumSearch.UnitTests
{
    [TestClass]
    public class MaxSumSearcherTests
    {
        private readonly ServiceCollection _serviceCollection = new();
        private ServiceProvider _provider;
        private IMaxSumSearcher _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _serviceCollection.AddScoped<IMaxSumSearcher, MaxSumSearcher>();
            _provider = _serviceCollection.BuildServiceProvider();
            _service = _provider.GetRequiredService<IMaxSumSearcher>();
        }

        [TestMethod]
        public void GetMaxSumLineTest_FileWithSecondMaxLine_LineTwo()
        {
            //Arrange
            var fileContent = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\AllLinesTest.txt");
            int expected = 2;

            //Act
            var actual = _service.GetMaxSumLineTest(fileContent);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBrokenLinesTest_FileWithThirdAndFourthBrokenLines_LinesThreeAndFour()
        {
            //Arrange
            var fileConten = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\AllLinesTest.txt");
            int[] expected = new[] { 3, 4 };

            //Act
            var actual = _service.GetBrokenLinesTest(fileConten);

            //Assert            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxSumLineTest_FileWithThirdMaxLine_LineThree()
        {
            //Arrange
            var fileContent = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\CorrectLinesOnlyTest.txt");
            int expected = 3;

            //Act
            var actual = _service.GetMaxSumLineTest(fileContent);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBrokenLinesTest_FileWithoutBrokenLines_Zero()
        {
            //Arrange
            var fileConten = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\CorrectLinesOnlyTest.txt");
            int[] expected = new[] { 0 };

            //Act
            var actual = _service.GetBrokenLinesTest(fileConten);

            //Assert            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxSumLineTest_FileWithBrokenLinesOnly_Zero()
        {
            //Arrange
            var fileContent = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\BrokenLinesOnlyTest.txt");
            int expected = 0;

            //Act
            var actual = _service.GetMaxSumLineTest(fileContent);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBrokenLinesTest_FileWithBrokenLinesOnly_AllLinesFromOneUntilSix()
        {
            //Arrange
            var fileConten = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\BrokenLinesOnlyTest.txt");
            int[] expected = new[] { 1, 2, 3, 4, 5, 6 };

            //Act
            var actual = _service.GetBrokenLinesTest(fileConten);

            //Assert            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxSumLineTest_EmptyFileForCorrectLines_Zero()
        {
            //Arrange
            var fileContent = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\EmptyOnlyTest.txt");
            int expected = 0;

            //Act
            var actual = _service.GetMaxSumLineTest(fileContent);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBrokenLinesTest_EmptyFileForBrokenLines_Zero()
        {
            //Arrange
            var fileConten = new FileContent(@"E:\Study\Ivan\C#\Fixminded Projects\MaxSumSearch\MaxSumSearch.UnitTests\testFiles\EmptyOnlyTest.txt");
            int[] expected = new[] { 0 };

            //Act
            var actual = _service.GetBrokenLinesTest(fileConten);

            //Assert            
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
