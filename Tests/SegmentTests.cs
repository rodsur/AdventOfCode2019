using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using AdventOfCode;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SegmentTests
    {
        private Segment _segment1;
        private Segment _segment2;
        private Segment _segment3;
        
        [SetUp]
        public void Setup()
        {
            _segment1 = new Segment(new int[]{2,3},'U',3 );
            _segment2 = new Segment(new int[]{3,2},'L',3 );
            _segment3 = new Segment(new int[]{4,0},'R',5 );
            
        }

        [Test]
        public void EndTest()
        {
            int[] seg1End = _segment1.getEnd();
            int[] seg2End = _segment2.getEnd();
            int[] seg3End = _segment3.getEnd();
            Assert.AreEqual(5,seg1End[0]);
            Assert.AreEqual(3,seg1End[1]);
            Assert.AreEqual(3,seg2End[0]);
            Assert.AreEqual(-1,seg2End[1]);
            Assert.AreEqual(4,seg3End[0]);
            Assert.AreEqual(5,seg3End[1]);
        }

        [Test]
        public void IntersectionTest()
        {
            List<Intersection> intersections = new List<Intersection>();
            //intersections.AddRange(_segment1.checkIntersections(_segment2));
            //Assert.AreEqual(0,intersections.Count);
            intersections.Clear();
            intersections.AddRange(_segment1.checkIntersections(_segment3));
            Assert.AreEqual(1,intersections.Count);
        }
    }
}