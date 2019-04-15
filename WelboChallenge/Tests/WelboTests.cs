using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WelboChallenge;

namespace Tests
{
    [TestClass]
    public class WelboTests
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        [Timeout(500)]
        public void GivenUserStartsProgram_WhenUserSaysHello_WelboSaysHelloBack()
        {
            // Arrange
            TestEnvironment testEnvironment = new TestEnvironment()

            // Act
            .UserSaysHello()
            .Initialize()

            // Assert
            .AssertGreetingIsGiven();
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        [Timeout(500)]
        public void GivenUserStartsProgram_WhenUserGivesUnrecognisedAnswer_WelboAsksToRepeat()
        {
            // Arrange
            TestEnvironment testEnvironment = new TestEnvironment()

            // Act
            .UserSaysHelloIncorrectly()
            .Initialize()

            // Assert
            .AssertThatUserIsPromptedToRepeatTheirAnswer();
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        [Timeout(500)]
        public void GivenUserStartsProgram_WhenUserSaysRegexVariant_WelboSaysHelloBack()
        {
            // Arrange
            TestEnvironment testEnvironment = new TestEnvironment()
            
            // Act
            .UserSaysElloElloEllo()
            .Initialize()

            // Assert
            .AssertGreetingIsGiven();
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [TestMethod]
        // [Timeout(500)]
        public void GivenUserSaysHello_WhenUserGivesName_WelboGivesAppointmentHostName()
        {
            // Arrange
            TestEnvironment testEnvironment = new TestEnvironment()

            // Act
            .UserSaysHelloAndYesAndEntersName()
            .Initialize()

            // Assert
            .AssertThatHostNameIsGiven();
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
