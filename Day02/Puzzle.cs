using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace Day02
{
    public class Puzzle
    {
        private readonly string _day;
        private int[] _input;
        private int _pc;
        private List<int> _ints;
        public Puzzle()
        {
            _pc = 0;
            _day = "day02";
            _input = initInput();
        }

        private int[] initInput()
        {
            string[] inputarr = File.ReadAllText(_day + "/input").Split(",");
            int[] outputarr = new int[inputarr.Length];
            for (int i = 0; i < inputarr.Length; i++)
            {
                outputarr[i] = Int32.Parse(inputarr[i]);
            }
            return outputarr;
        }

        public void run()
        {
            Part1();
        }

        private void Part1()
        {
            _input[1] = 12;
            _input[2] = 2;
            runProgram();
            Console.WriteLine(_input[0]);
        }

        private void runProgram()
        {
            bool running = true;
            while (running)
            {
                int cmd = _input[_pc];
                int arg1 = _input[_input[_pc + 1]];
                int arg2 = _input[_input[_pc + 2]];
                int savepos = _input[_pc + 3];
                switch (cmd)
                {
                    case(1):
                        Console.WriteLine("Running add command at: " + _pc);
                        Console.WriteLine("Args: " + arg1 + " " + arg2);
                        Console.WriteLine("Save pos: " + savepos);
                        add(arg1, arg2, savepos);
                        Console.WriteLine("Result at " + savepos +": " + _input[savepos]);
                        break;
                    case(2):
                        Console.WriteLine("Running multiply command at: " + _pc);
                        Console.WriteLine("Args: " + arg1 + " " + arg2);
                        Console.WriteLine("Save pos: " + _input[_pc+3]);
                        mult(arg1,arg2,savepos);
                        break;
                    case(99):
                        Console.WriteLine("Halting...");
                        running = false;
                        break;
                    default:
                        running = false;
                        Console.WriteLine("Unsupported Operation");
                        break;
                }
                _pc += 4;
            }
        }

        private void add(int i1, int i2, int savpos)
        {
            _input[savpos] = i1 + i2;
        }

        private void mult(int i1, int i2, int savpos)
        {
            _input[savpos] = i1 * i2;
        }
    }
}