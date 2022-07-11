using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Robot
    {
        private List<string> words = new List<string> 
        { 
            "i", "do", "not", "understand", "the", "input",
            "already", "know", "word",
            "thank", "you", "for", "teaching", "me"
        };

        public string LearnWord(string word)
        {
            if (word.Length < 1 || word.Any(c => !char.IsLetter(c))) return "I do not understand the input";
            if (words.Contains(word.ToLower())) return $"I already know the word {word}";
            else
            {
                words.Add(word.ToLower());
                return $"Thank you for teaching me {word}";
            }
        }
    }
}
