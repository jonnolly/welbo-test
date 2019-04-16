using NSubstitute;
using WelboChallenge;

namespace Tests
{
    public class TestEnvironment
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Constructor
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment()
        {
            _userInteractionSub = Substitute.For<IUserInteraction>();
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Acts
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment UserSaysHello()
        {
            _userInteractionSub.ReadConsoleLine().Returns("hello");

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment UserSaysHelloIncorrectly()
        {
            _userInteractionSub.ReadConsoleLine().Returns("hellop");

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment UserSaysHelloAndYesAndEntersNameAndSaysYes()
        {
            _userInteractionSub.ReadConsoleLine().Returns("hello", "yes", _testVisitorName, "yes");

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment UserSaysElloElloEllo()
        {
            _userInteractionSub.ReadConsoleLine().Returns("Ello ello ello");

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // must be run immediately after the last "Act" has been used in a test
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment Initialize()
        {
            WelboApplication.RunApplication(_userInteractionSub);

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Asserts
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment AssertGreetingIsGiven()
        {
            _userInteractionSub.Received(1).WriteConsoleLine(Arg.Is(_greeting));

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment AssertThatHostNameIsGiven()
        {
            _userInteractionSub.Received(1).WriteConsoleLine(Arg.Is("You have an appointment with Roeland van Oers.\n Would you like to check in for this appointment?"));

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TestEnvironment AssertThatUserIsPromptedToRepeatTheirAnswer()
        {
            // 10 calls corresponding to the number of retries before timeout
            _userInteractionSub.Received(10).WriteConsoleLine(Arg.Is(_repeatAnswerPrompt));

            return this;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // private
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private IUserInteraction _userInteractionSub;
        private const string _testVisitorName = "Stanislav Minev";
        private const string _testEmployeeName = "Roeland van Oers";
        private const string _greeting = "Hello and welcome! Are you here for an appointment?";
        private const string _repeatAnswerPrompt = "Sorry I didn't understand. Could you rephrase that for me please?";

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
