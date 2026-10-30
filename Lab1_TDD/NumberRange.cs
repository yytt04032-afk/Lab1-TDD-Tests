using System;

namespace Lab1_TDD
{
    public class NumberRange
    {
        private double _left;
        private double _right;

        public double Left
        {
            get { return _left; }
            set
            {
                if (value > _right) throw new ArgumentException("Ліва межа не може бути більшою за праву.");
                _left = value;
            }
        }

        public double Right
        {
            get { return _right; }
            set
            {
                if (value < _left) throw new ArgumentException("Права межа не може бути меншою за ліву.");
                _right = value;
            }
        }

        public NumberRange()
        {
            _left = 0.0;
            _right = 0.0;
        }

        public NumberRange(double left, double right)
        {
            if (left > right) throw new ArgumentException("Ліва межа не може бути більшою за праву.");
            _left = left;
            _right = right;
        }

        public NumberRange(NumberRange other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            _left = other._left;
            _right = other._right;
        }

        public double GetLength()
        {
            return _right - _left;
        }

        public bool Contains(double value)
        {
            return value >= _left && value <= _right;
        }

        public bool Intersects(NumberRange other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return _left <= other._right && other._left <= _right;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            NumberRange other = (NumberRange)obj;
            return Math.Abs(_left - other._left) < 0.0001 && Math.Abs(_right - other._right) < 0.0001;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(_left, _right).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[{0}; {1}]", _left, _right);
        }
    }
}