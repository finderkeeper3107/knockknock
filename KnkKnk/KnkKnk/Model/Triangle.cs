using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnkKnk.Model
{
    public enum TriangleType
    {
        Equilateral,
        Isosceles,
        Scalene,
        Error

    }
    public class Triangle
    {
        private int _a { get; set; }
        private int _b { get; set; }
        private int _c { get; set; }

        public TriangleType TriangleType { get; set; }
        public Triangle(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
            FindTriangleType();
        }
        private void FindTriangleType()
        {
            if (_a <= 0 || _b <= 0 || _c <= 0)
            {
                TriangleType = TriangleType.Error;
                return;
            }
            if (_a + _b <= _c || _b + _c <= _a || _c + _a <= _b)
            {
                TriangleType = TriangleType.Error;
                return;
            }
            int[] sides = new int[] { _a, _b, _c };
            int distinctSideCount = sides.Distinct().Count();
            if (distinctSideCount == 1)
            {
                TriangleType = TriangleType.Equilateral;
            }
            if (distinctSideCount == 2)
            {
                TriangleType = TriangleType.Isosceles;
                return;
            }
            if (distinctSideCount == 3)
            {
                TriangleType = TriangleType.Scalene;
                return;
            }
        }
    }
}
