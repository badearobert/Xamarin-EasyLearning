using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinfachDeutsch.Common
{
    public class Helper
    {
        public static bool ValidateAnswer(string expected, string input)
        {
            // todo improve - replace öïäëü without vowels, string difference to be 0-1, etc
            List<string> answers = expected.Split(',').ToList();
            foreach (string answer in answers)
            {
                if (input == answer) return true;
            }
            return false;
        }
    }
}
