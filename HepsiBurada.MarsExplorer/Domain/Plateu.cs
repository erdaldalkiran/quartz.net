﻿namespace Domain
{
    public sealed class Plateu
    {
        private readonly int _height;

        private readonly int _width;

        public Plateu(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public bool IsCoordinateInsideTheArea(Coordinate coordinate)
        {
            if (coordinate.X >= 0 && coordinate.X <= _width && coordinate.Y >= 0 && coordinate.Y <= _height)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", _width, _height);
        }
    }
}