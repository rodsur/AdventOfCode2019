using System;
using AdventOfCode;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Day03P1Tests
    {
        private Day3Part1 puzzle;
        [SetUp]
        public void Setup()
        {
            puzzle = new Day3Part1();
        }

        [Test]
        public void Test1()
        {
            String[] input = new[] {"R8,U5,L5,D3", "U7,R6,D4,L4"};
            puzzle.LoadInput(input);
            Assert.AreEqual(6,puzzle.Run());
        }
        
        [Test]
        public void Test2()
        {
            String[] input = new[] {"R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83"};
            puzzle.LoadInput(input);
            Assert.AreEqual(159,puzzle.Run());
        }
        
        [Test]
        public void Test3()
        {
            String[] input = new[] {"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"};
            puzzle.LoadInput(input);
            Assert.AreEqual(135,puzzle.Run());
        }
    }
}