using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pimsporter.Adapter;
using Pimsporter.Service;

namespace PimsporterTest.Adapter
{
    [TestClass]
    public class ConsoleAdapterTest
    {
        [TestMethod]
        public void IfDefaultUsernameEmptyReturnFromConsole()
        {
            // Arrange
            var settingsServiceMock = new SettingsServiceMock("");
            var consoleWrapperMock = new ConsoleWrapperMock(true);
            var console = new ConsoleAdapter(consoleWrapperMock, settingsServiceMock);
            var expected = @"mydomain\username";

            // Act
            string actual = console.GetUsername();

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void IfDefaultUsernameNotOKReturnFromConsole()
        {
            var settingsServiceMock = new SettingsServiceMock("valami");
            var consoleWrapperMock = new ConsoleWrapperMock(false);
            var console = new ConsoleAdapter(consoleWrapperMock, settingsServiceMock);
            var expected = @"mydomain\username";

            // Act
            string actual = console.GetUsername();

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void IfDefaultUsernameOKReturnIt()
        {
            var settingsServiceMock = new SettingsServiceMock(@"mydomain\username");
            var consoleWrapperMock = new ConsoleWrapperMock(true);
            var console = new ConsoleAdapter(consoleWrapperMock, settingsServiceMock);
            var expected = @"mydomain\username";

            // Act
            string actual = console.GetUsername();

            // Assert
            Assert.AreEqual(actual, expected);
        }
    }

    class SettingsServiceMock : ISettingsService
    {
        private string defaultUsername;

        public SettingsServiceMock(string username)
        {
            defaultUsername = username;
        }

        public string GetDefaultUsername()
        {
            return defaultUsername;
        }

        public void SaveDefaultUsername(string username)
        {
        }
    }

    class ConsoleWrapperMock : IConsoleWrapper
    {
        private string userAnswer;

        public ConsoleWrapperMock(bool userAccepted)
        {
            if (userAccepted)
                userAnswer = "y";
            else
                userAnswer = "n";
        }
        public string GetUsername()
        {
            return @"mydomain\username";
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            return userAnswer;
        }

        public void Write(string value)
        {
        }

        public void Write(string format, params object[] args)
        {
        }

        public void WriteLine()
        {
        }

        public void WriteLine(string value)
        {
        }

        public void WriteLine(string format, params object[] args)
        {            
        }
    }
}
