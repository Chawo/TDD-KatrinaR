using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class myCalculator
    {
        public List<char> delimiter = new List<char> { ' ', ',', '\r', '\n' };

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else if (numbers.StartsWith("//"))
            {
                delimiter.Add(numbers[2]);
                numbers = numbers.Replace("//", "");

                List<int> sum = new List<int>();
                // Nu är "//" det borta
                // Nu finns det bara \n
                // Alltså ser det ut så här ; | 12
                string[] _numbers = numbers.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var number in _numbers)
                {
                    sum.Add(int.Parse(number));

                }
                int total = sum.Sum(x => Convert.ToInt32(x));

                return total;
            }
            else if (!numbers.Contains(","))
            {
                return int.Parse(numbers);
            }
            else
            {
                // Use a char array of 2 characters (, and \r and \n).
                List<int> sum = new List<int>();

                // ... Break lines into separate strings.
                // ... Use RemoveEntryEntries to make sure empty strings not are added.
                string[] _numbers = numbers.Split(delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                // Här adderar den numret i listan.
                foreach (var number in _numbers)
                {
                    sum.Add(int.Parse(number));
                }

                // Det här summerar upp allt i listan
                int total = sum.Sum(x => Convert.ToInt32(x));         

                return total;

            }

        }

    }
}
