using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Wire
    {
        public List<Segment> _segments { get; }
        public List<(int x,int y)> _points { get; }

        public Wire(string input)
        {
            string[] Directions = input.Split(",");
            int[] start = new[] {0, 0};
            _points = new List<(int, int)>();
            _points.Add((0,0));
            _segments = new List<Segment>();
            foreach (var segment in Directions)
            {
                _segments.Add(new Segment(start,segment[0],Int32.Parse(segment.Substring(1))));
                start = _segments[^1].getEnd();
                for (int i = 0; i < Int32.Parse(segment.Substring(1)); i++)
                {
                    var lastPoint = _points[^1];
                    //var lastPoint = _points.Last();
                    switch (segment[0])
                    {
                        case 'U':
                             _points.Add((lastPoint.x+1,lastPoint.y));
                            break;
                        case 'D':
                            _points.Add((lastPoint.x-1,lastPoint.y));
                            break;
                        case 'L':
                            _points.Add((lastPoint.x,lastPoint.y-1));
                            break;
                        case 'R':
                            _points.Add((lastPoint.x,lastPoint.y+1));
                            break;
                    }
                }
            }
            /*
            foreach (var point in _points)
            {
                Console.WriteLine("x: " + point.x + ", y: " + point.y);
            }
            Console.WriteLine("Wire done");
            */
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
        
        public int calculateDistance(List<(int,int)> list)
        {
            List<Intersection> intersections = new List<Intersection>();
            foreach (var item in list)
            {
                intersections.Add(new Intersection(item.Item1,item.Item2));
            }

            return calculateDistance(intersections);
        }

        public List<(int, int)> CheckIntersections(Wire wire)
        {
            
            List<(int,int)> returnlist= new List<(int, int)>();
            returnlist.AddRange(_points.Intersect(wire._points));
            return returnlist;
        }
    }
}