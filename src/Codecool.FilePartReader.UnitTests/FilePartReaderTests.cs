using System;
using System.Collections.Generic;
using System.IO;
using Codecool.FilePartReader;
using NUnit.Framework;

namespace Codecool.FilePartReader.UnitTests
{
    /// <summary>
    /// When testing a class you should test only that specific class(unit), not the others
    /// the class may depending on
    /// 
    /// See code review comments in pull request.
    /// </summary>
    [TestFixture]
    public class FilePartReaderTest
    {
        private FilePartReader _filePartReader;

        [SetUp]
        public void Setup()
        {
            _filePartReader = new FilePartReader();
            // comment?
            //_filePartReader.Setup();
        }

        [Test]
        public void Constructor_Default_FilePathHasDefaultValue()
        {
            // Arrange
            var defaultPath = string.Empty;
            // Act
            FilePartReader reader = new FilePartReader();
            // Assert
            Assert.AreEqual(defaultPath, reader.FilePath);
        }

        [Test]
        public void GetStringsWhichPalindromes_ContainsPalindromes_ReturnPalindromesAsList()
        {
            // Arrange
            var defaultPath = string.Empty;
            FilePartReader reader = new FilePartReader();
            reader.Setup("test.txt", 1, 7);
            var analyzer = new FileWordAnalyzer(reader);
            var expected = new List<string>()
            {
                "kajak",
                "lol",
                "görög"
            };

            // Act
            var palindromes = analyzer.GetStringsWhichPalindromes();

            // Assert
            CollectionAssert.AreEqual(expected, palindromes);
        }

        [Test]
        public void Setup_FromLineBiggerThanToLine_HasNoReturn()
        {
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("test.txt", 5, 3));
        }

        [Test]
        public void Setup_FromLineIsSmallerThanOne_HasNoReturn()
        {
            // Arrange? Act?
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("test.txt", -1, 3));
        }

        [Test]
        public void ReadLines_CreateString_ReturnResult()
        {
            _filePartReader.Setup("test.txt", 3, 6);
            string expected = "Codecool\r\nlol\r\ntest\r\nGeri\r\n";

            Assert.AreEqual(expected, _filePartReader.ReadLines());
        }

        [Test]
        public void GetWordsOrderedAlphabetically_SortWords_ReturnSortedList()
        {
            // This is an Analyzer test not FilePartReader test -> should be in separated test file
            _filePartReader.Setup("test.txt", 2, 6);
            var expected = "Codecool, Geri, kajak, lol, test";
            var analyzer = new FileWordAnalyzer(_filePartReader);

            var sortedList = analyzer.GetWordsOrderedAlphabetically();

            Assert.AreEqual(expected, sortedList);

        }

        [Test]
        public void GetWordsContainingSubstring_ContainsSubString_ReturnListOfWords()
        {
            // same as above
            _filePartReader.Setup("test.txt", 1, 7);
            var analyzer = new FileWordAnalyzer(_filePartReader);
            var expected = "Codecool";

            var wordList = analyzer.GetWordsContainingSubstring("cool");

            Assert.AreEqual(expected, wordList);
        }

    }
}
