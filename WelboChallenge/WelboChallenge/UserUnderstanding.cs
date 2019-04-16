using System.Linq;
using System.Text.RegularExpressions;

namespace WelboChallenge
{
    public class UserUnderstanding
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public UserUnderstanding(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }
        
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public bool ReadUserInput(ref string userInput, string[] greetingVariations = null, string[] greetingMatchers = null)
        {
            int nTries = 0;
            bool bSuccessfulUserInput = false;

            while (!bSuccessfulUserInput && nTries++ < _nTimeoutTries)
            {
                var input = _userInteraction.ReadConsoleLine();
                bSuccessfulUserInput = InputMatchesVariations(input, greetingVariations, greetingMatchers);

                if (bSuccessfulUserInput)
                    userInput = input;
                else
                    _userInteraction.WriteConsoleLine("Sorry I didn't understand. Could you rephrase that for me please?");
            }

            return bSuccessfulUserInput;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // private
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private IUserInteraction _userInteraction;
        private int _nTimeoutTries = 10;

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool InputMatchesVariations(string userInput, string[] inputVariations, string[] inputMatchers)
        {
            // if no matchers or variations provided, accept all user input
            if (inputVariations == null && inputMatchers == null)
                return true;

            // lowercase, so that any case is accepted
            var userInputLowercase = userInput.ToLower();

            bool exactMatch = false;
            bool regexMatch = false;

            if (inputVariations != null)
                exactMatch = inputVariations.Contains(userInputLowercase);

            if (inputMatchers != null)
                regexMatch = inputMatchers.Any(inputMatcher => Regex.IsMatch(userInputLowercase, inputMatcher));

            return exactMatch || regexMatch;
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
