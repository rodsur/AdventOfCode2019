using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace AdventOfCode
{
    public class Segment
    {
        public int[] start { get; }
        private int[] direction { get; }
        private int length;

        public Segment(int[] start, char direction, int length)
        {
            this.start = start;
            this.length = length;
            switch (direction)
            {
                case 'U':
                    this.direction = new[] {1, 0}; 
                    break;
                case 'D':
                    this.direction = new[] {-1, 0};
                    break;
                case 'L':
                    this.direction = new[] {0, -1};
                    break;
                case 'R':
                    this.direction = new[] {0, 1};
                    break;
            }
        }

        public int[] getEnd()
        {
            int[] end = new int[start.Length];
            for (int i = 0; i < start.Length; i++)
            {
                end[i] = (direction[i] * length) + start[i];
            }
            return end;
        }

        public List<Intersection> checkIntersections(Segment segment)
        {
            List<Intersection> intersections = new List<Intersection>();
            int[] coords = {start[0],start[1]};
            for (int i = 0; i < length; i++)
            {
                coords[0] = start[0] + (direction[0] * i);
                coords[1] = start[1] + (direction[1] * i);
                int[] segmentcoords = {segment.start[0], segment.start[1]};
                for (int j = 0; j < length; j++)
                {
                    segmentcoords[0] = segmentcoords[0] + (segment.direction[0] * j);
                    segmentcoords[1] = segmentcoords[1] + (segment.direction[1] * j);

                    if (coords[0] == segmentcoords[0] && coords[1] == segmentcoords[1])
                    {
                        intersections.Add(new Intersection(coords[0],coords[1]));
                    }
                }
            }
            return intersections;
        }

        public override string ToString()
        {
            return "Starts at: " + start[0] + "," + start[1];
        }
    }
}