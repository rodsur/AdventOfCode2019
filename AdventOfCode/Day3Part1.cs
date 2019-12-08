using System;

namespace AdventOfCode
{
    public class Day3Part1 : IPuzzle
    {

        private String[] _input;
        private Wire[] _wires;

        public int Run()
        {
            return _wires[0].calculateDistance(_wires[0].CheckCollision(_wires[1]));
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