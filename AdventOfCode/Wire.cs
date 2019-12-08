using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Wire
    {
        public List<Segment> _segments { get; }

        public Wire(string input)
        {
            string[] Directions = input.Split(",");
            int[] start = new[] {0, 0};
            _segments = new List<Segment>();
            foreach (var segment in Directions)
            {
                _segments.Add(new Segment(start,segment[0],Int32.Parse(segment.Substring(1))));
                start = _segments[^1].getEnd();
            }
        }

        public List<Intersection> CheckCollision(Wire wire)
        {
            List<Intersection> intersections = new List<Intersection>();
            foreach (var segment in _segments)
            {
                foreach (var wireSegment in wire._segments)
                {
                    intersections.AddRange(segment.checkIntersections(wireSegment));
                }
            }
            return intersections;
        }

        public int calculateDistance(List<Intersection> list)
        {
            int lowestDistance = 0;
            foreach (var intersection in list)
            {
                int distance = Math.Abs(intersection.x) + Math.Abs(intersection.y);
                Console.WriteLine("x: " + Math.Abs(intersection.x) + " " + intersection.y);
                Console.WriteLine("distance is: " + distance);
                if (lowestDistance == 0 || distance<lowestDistance)
                {
                    lowestDistance = distance;
                    Console.WriteLine("Distance set to: " + lowestDistance);
                }
            }

            return lowestDistance;
        }
    }
}