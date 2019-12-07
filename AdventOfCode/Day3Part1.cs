using System;

namespace AdventOfCode
{
    public class Day3Part1 : IPuzzle
    {

        private String[] _input;
        private Wire[] _wires;

        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public void LoadInput(string[] input)
        {
            _input = input;
            _wires = new Wire[_input.Length];
            for (int i = 0; i < _input.Length; i++)
            {
                _wires[i] = new Wire(_input[i]);
            }
        }
    }
}