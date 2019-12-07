using System;

namespace AdventOfCode
{
    public class Wire
    {
        private string[] Directions { get; }

        public Wire(string input)
        {
            Directions = input.Split(",");
        }


        public int[] CheckCollision(Wire wire)
        {
            int[] ownCoords = new[] {0, 0};
            
            return null;
        }
        
    }
}