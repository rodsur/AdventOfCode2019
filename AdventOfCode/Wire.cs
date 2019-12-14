using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Wire
    {
        public List<(int x,int y)> _points { get; }

        public Wire(string input)
        {
            string[] Directions = input.Split(",");
            int[] start = new[] {0, 0};
            _points = new List<(int, int)>();
            _points.Add((0,0));
            foreach (var segment in Directions)
            {
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
        }

        public int CalculateDistance(List<(int x,int y)> list)
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

        public List<(int, int)> CheckIntersections(Wire wire)
        {
            
            List<(int,int)> returnlist= new List<(int, int)>();
            returnlist.AddRange(_points.Intersect(wire._points));
            return returnlist;
        }


        public int CalculateShortestDelay(Wire wire)
        {
            int shortestDelay = 0;
            List<(int x, int y)> intersectionList = CheckIntersections(wire);
            foreach (var intersection in intersectionList)
            {
                int distance = wire._points.IndexOf((intersection.x, intersection.y)) +
                               this._points.IndexOf((intersection.x, intersection.y));
                if (shortestDelay == 0 || distance < shortestDelay)
                {
                    shortestDelay = distance;
                }
            }

            return shortestDelay;
        }
    }
}