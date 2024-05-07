using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using PUXTask.Classes;
using System.Collections.Generic;
using System.Linq;

namespace PUXTask.Tests
{
    [TestClass]
    public class UnitTest1
    {
        readonly static string logFile = @"C:\Temp\PUXTask.test.debug";

        public static void MyDebug(string message)
        {
            message = message + Environment.NewLine;

            if (File.Exists(logFile))
                File.AppendAllText(logFile, message);
            else
                File.WriteAllText(logFile, message);
        }

        [TestInitialize]
        public void Setup()
        {
            File.WriteAllText(logFile, $"Debug PUX test {DateTime.Now.ToString() + Environment.NewLine}");
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestGetAllFiles()
        {
            /*
            //Console.Write("TestGetAllFiles");
            //Trace.Write("TestGetAllFiles");
            //Debug.Write("TestGetAllFiles");
            MyDebug("TestGetAllFiles");

            MyFiles f = new MyFiles();
            string path = "C:\\Temp";
            //List<string> files = f.GetAllFiles(path);
            IEnumerable<FileInfo> files = f.GetAllFiles(path);

            MyDebug(path);
            if (files == null)
            {
                MyDebug("Složka neobsahuje žádný soubor.");
                Assert.Fail("Složka neobsahuje žádný soubor.");
            }

            //MyDebug(files.Count.ToString());
            MyDebug($"{files.Count()}");

            //foreach (string file in files)
            foreach (var file in files)
            {
                //Trace.WriteLine(file);
                MyDebug(file.FullName);

                //string fileMd5 = Path.GetDirectoryName(file) + @"\" + Path.GetFileNameWithoutExtension(file) + ".md5";
                //MyDebug(fileMd5);

                //if (File.Exists(fileMd5))
                //    MyDebug(File.ReadAllText(fileMd5));
            }
            */
        }
    }
}
