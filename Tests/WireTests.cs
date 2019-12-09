using System.Collections.Generic;
using AdventOfCode;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WireTests
    {
        private Wire wire1;
        private Wire wire2;
        private Wire wire3;
        
        [SetUp]
        public void Setup()
        {
            wire1 = new Wire("R8,U5,L5,D3");
            wire2 = new Wire("U7,R6,D4,L4");
            wire3 = new Wire("R75,D30,R83,U83,L12,D49,R71,U7,L72");
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(4,wire1._segments.Count);
            Assert.AreEqual(4,wire2._segments.Count);
        }

        [Test]
        public void IntersectionsTest()
        {
            List<Intersection> intersections = new List<Intersection>();
            List<(int,int)> intersectionlist = new List<(int, int)>();
            intersections.AddRange(wire1.CheckCollision(wire2));
            intersectionlist.AddRange(wire1.CheckIntersections(wire2));
            Assert.AreEqual(2,intersections.Count);
            Assert.AreEqual(2,intersections.Count);
        }

        [Test]
        public void DistanceTest()
        {
            List<Intersection> intersections = new List<Intersection>();
            intersections.Add(new Intersection(5,8));
            Assert.AreEqual(13,wire1.calculateDistance(intersections));
            intersections.Clear();
            intersections.Add(new Intersection(135,37));
            Assert.AreEqual(172,wire1.calculateDistance(intersections));
            intersections.Add(new Intersection(135,30));
            Assert.AreEqual(165,wire1.calculateDistance(intersections));
        }

        [Test]
        public void AttachmentTest()
        {
            for (int i = 0; i < wire3._segments.Count - 1; i++)
            {
                Assert.AreEqual(wire3._segments[i].getEnd(),wire3._segments[i+1].start);
            }
        }
    }
}