using System;

namespace AdventOfCode
{
    public interface IPuzzle
    {
        int Run();
        void LoadInput(String[] input);
        
    }
}