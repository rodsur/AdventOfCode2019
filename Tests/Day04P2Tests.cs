using System;
using AdventOfCode;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Day04P2Tests
    {
        private Day4Part2 puzzle;
        private String[] input;
        
        [SetUp]
        public void Setup()
        {
            puzzle = new Day4Part2();
        }

        [Test]
        public void Test1()
        {
            input = new[] {"165432-707912"};
            puzzle.LoadInput(input);
            Assert.AreEqual(1163,puzzle.Run());
        }
    }
}