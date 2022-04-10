namespace FileLibrary.Tests
{
    using FileLibrary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Reflection;

    [TestClass]
    public class FileByteTests
    {
        [TestMethod]
        public void GetName_ok()
        {
            Uri currentExe = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase, UriKind.Absolute);
            Assert.AreEqual("FileByteTeste", FileByte.GetName(currentExe.LocalPath));
        }

        [TestMethod]
        public void GetType_ok()
        {
            Uri currentExe = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase, UriKind.Absolute);
            Assert.AreEqual("DLL", FileByte.GetType(currentExe.LocalPath));
        }

        [TestMethod]
        public void GetNameAndType_ok()
        {
            Uri currentExe = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase, UriKind.Absolute);
            Assert.AreEqual("FileByteTeste.DLL", FileByte.GetNameAndType(currentExe.LocalPath));
        }

        [TestMethod]
        public void ConvertFilePathToByte_ok()
        {
            Uri currentExe = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase, UriKind.Absolute);

            Assert.AreNotEqual(new byte[0], FileByte.ConvertFilePathToByte(currentExe.LocalPath));
        }

        [TestMethod]
        public void SaveByteInPath_ok()
        {
            Uri currentExe = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase, UriKind.Absolute);
            int index = currentExe.LocalPath.LastIndexOf(@"\");
            var path = currentExe.LocalPath.Substring(0, index);

            var byteFile = FileByte.ConvertFilePathToByte(currentExe.LocalPath);

            Assert.IsTrue(FileByte.SaveByteInPath(path, "teste.dll", byteFile));
        }
    }
}
