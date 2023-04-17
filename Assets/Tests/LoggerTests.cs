using MGS.Logger;
using NUnit.Framework;
using System;
using System.IO;
using UnityEngine;

namespace Tests
{
    public class LoggerTests
    {
        [Test]
        public void TestOutputLog()
        {
            LogUtility.Log("Test output log message.");
            LogUtility.LogWarning("Test output warning message.");
            //LogUtility.LogError("Test output error message.");

            var fileName = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = $"{Application.persistentDataPath}/Log/{fileName}.log";
            Assert.IsTrue(File.Exists(filePath));

            var content = File.ReadAllText(filePath);
            Assert.IsFalse(string.IsNullOrEmpty(content));
        }
    }
}