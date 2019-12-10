using System;

namespace AdventOfCode
{
    public class Day4Part2
    {
        private int _min;
        private int _max;
        
        public int Run()
        {
            
            return Password.checkPasswordsStrict(_min,_max);
        }

        public void LoadInput(string[] input)
        {
            input = input[0].Split("-");
            _min = Int32.Parse(input[0]);
            _max = Int32.Parse(input[1]);
        }
    }
}