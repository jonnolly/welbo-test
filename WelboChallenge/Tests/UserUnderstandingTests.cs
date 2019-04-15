using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelboChallenge;

namespace Tests
{
    [TestClass]
    public class UserUnderstandingTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            _userInteraction = Substitute.For<IUserInteraction>();
            _userUnderstanding = new UserUnderstanding(_userInteraction);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        public void GivenNoVariationsOrMatchersAreApplied_WhenReadingUserInput_UserInputIsReadAndApproved()
        {
            // Arrange
            var outputString = "test output";
            _userInteraction.ReadConsoleLine().Returns(outputString);

            // Act
            string userInput = "";
            var successfulUserInput = _userUnderstanding.ReadUserInput(ref userInput);

            // Assert
            Assert.AreEqual(outputString, userInput);
            Assert.AreEqual(true, successfulUserInput);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        public void GivenVariationsAreGiven_WhenReadingMatchingUserInput_ValidInputIsReadAndApproved()
        {
            // Arrange
            var outputString = "test output";
            _userInteraction.ReadConsoleLine().Returns(outputString);

            // Acts
            string userInput = "";
            var successfulUserInput = _userUnderstanding.ReadUserInput(ref userInput, new string[] { "test output" });

            // Assert
            Assert.AreEqual(outputString, userInput);
            Assert.AreEqual(true, successfulUserInput);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        public void GivenVariationsAreGiven_WhenReadingNonMatchingUserInput_UserInputIsDenied()
        {
            // Arrange
            var outputString = "test output";
            _userInteraction.ReadConsoleLine().Returns(outputString);

            // Acts
            string userInput = "";
            var successfulUserInput = _userUnderstanding.ReadUserInput(ref userInput, new string[] { "test output - not matching" });

            // Assert
            Assert.AreEqual("", userInput);
            Assert.AreEqual(false, successfulUserInput);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        public void GivenMatchersAreGiven_WhenReadingMatchingUserInput_UserInputIsApproved()
        {
            // Arrange
            var outputString = "test output";
            _userInteraction.ReadConsoleLine().Returns(outputString);

            // Acts
            string userInput = "";
            var successfulUserInput = _userUnderstanding.ReadUserInput(ref userInput, new string[] { "test output" });

            // Assert
            Assert.AreEqual(outputString, userInput);
            Assert.AreEqual(true, successfulUserInput);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        public void GivenMatchersAreGiven_WhenReadingNonMatchinUserInput_UserInputIsDenied()
        {
            // Arrange
            var outputString = "nonMatchingTestOutput";
            _userInteraction.ReadConsoleLine().Returns(outputString);

            // Acts
            string userInput = "";
            string[] nameRegex = { "([a-zA-Z]+\\s*\\b){2,}" };
            var successfulUserInput = _userUnderstanding.ReadUserInput(ref userInput, null, nameRegex);

            // Assert
            Assert.AreEqual("", userInput);
            Assert.AreEqual(false, successfulUserInput);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // private
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        UserUnderstanding _userUnderstanding;
        IUserInteraction _userInteraction;

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
