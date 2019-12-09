using System;
using AdventOfCode;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Day04P1Tests
    {
        private Day4Part1 puzzle;
        private String[] input;
        
        [SetUp]
        public void Setup()
        {
            puzzle = new Day4Part1();
        }

        [Test]
        public void Test1()
        {
            input = new[] {"165432-707912"};
            puzzle.LoadInput(input);
            Assert.AreEqual(1716,puzzle.Run());
        }
    }
}