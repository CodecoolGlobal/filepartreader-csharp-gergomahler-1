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
    /// </summary>
    [TestFixture]
    public class FilePartReaderTest
    {
        private FilePartReader _filePartReader;

        [SetUp]
        public void Setup()
        {
            _filePartReader = new FilePartReader();
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
            reader.Setup("test.txt", 1, 5);
            var analyzer = new FileWordAnalyzer(reader);
            var expected = new List<string>()
            {
                "kajak",
                "lol"
            };

            // Act
            var palindromes = analyzer.GetStringsWhichPalindromes();

            // Assert
            CollectionAssert.AreEqual(expected, palindromes);
        }

    }
}