using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class myCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else if (!numbers.Contains(","))
            {
                return int.Parse(numbers);
            }
            else
            {
                var myNumbers = new List<int>();
                // Skapa så att när det kommer fler nummer i stringen ska de summeras ihop
                return 0;

            }

        }

    }
}
