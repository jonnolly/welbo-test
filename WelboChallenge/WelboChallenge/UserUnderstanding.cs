using System.Linq;
using System.Text.RegularExpressions;

namespace WelboChallenge
{
    public class UserUnderstanding
    {
        public UserUnderstanding(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        /// <summary>
        /// Prompts the user to provide a response
        /// </summary>
        /// <param name="greetingVariations"></param>
        /// <param name="greetingMatchers"></param>
        public void ReadUserInput(string[] greetingVariations, string[] greetingMatchers)
        {
            int nTries = 0;
            bool bSuccessfulUserInput = false;
            while(!bSuccessfulUserInput && nTries++ < _nTimeoutTries)
            {
                var input = _userInteraction.ReadConsoleLine();
                bSuccessfulUserInput = InputMatchesVariations(input, greetingVariations, greetingMatchers);

                if (!bSuccessfulUserInput)
                    _userInteraction.WriteConsoleLine("Sorry I didn't understand. Could you rephrase that for me please?");
            }
        }

        /// <summary>
        /// Reads user input and returns whether it matches variations
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="inputVariations"></param>
        /// <param name="inputMatchers"></param>
        /// <returns>whether or not the string matched the inputted variations</returns>
        private bool InputMatchesVariations(string userInput, string[] inputVariations = null, string[] inputMatchers = null)
        {
            // lowercase, so that any case is accepted
            var userInputLowercase = userInput.ToLower();

            bool exactMatch = false;
            bool regexMatch = false;

            if (inputVariations?.Count() > 0)
                exactMatch = inputVariations.Contains(userInputLowercase);

            if(inputMatchers?.Count() > 0)
                regexMatch = inputMatchers.Any(inputMatcher => Regex.IsMatch(userInputLowercase, inputMatcher));

            return exactMatch || regexMatch;
        }

        private IUserInteraction _userInteraction;
        private int _nTimeoutTries = 10;
    }
}
