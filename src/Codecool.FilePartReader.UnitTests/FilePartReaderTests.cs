using System;
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

        //[Test]

    }
}