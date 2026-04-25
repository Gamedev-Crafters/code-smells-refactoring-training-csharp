using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private int _y;
        private int _x;
        private Direction _direction;

        public Rover(int x, int y, string direction)
        {
            _direction = new Direction(direction);
            _y = y;
            _x = x;
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    _direction = _direction.RotateLeft();

                }
                else if (command.Equals("r"))
                {
                    // Rotate Rover Right
                    if (_direction.Cardinality.Equals("N"))
                    {
                        if (true)
                        {
                            _direction = new Direction("E");
                        }
                    }
                    else if (_direction.Cardinality.Equals("S"))
                    {
                        if (true)
                        {
                            _direction = new Direction("W");
                        }
                    }
                    else if (_direction.Cardinality.Equals("W"))
                    {
                        if (true)
                        {
                            _direction = new Direction("N");
                        }
                    }
                    else
                    {
                        if (true)
                        {
                            _direction = new Direction("S");
                        }
                    }
                }
                else
                {
                    // Displace Rover
                    var displacement1 = -1;

                    if (command.Equals("f"))
                    {
                        displacement1 = 1;
                    }

                    var displacement = displacement1;

                    if (_direction.Cardinality.Equals("N"))
                    {
                        _y += displacement;
                    }
                    else if (_direction.Cardinality.Equals("S"))
                    {
                        _y -= displacement;
                    }
                    else if (_direction.Cardinality.Equals("W"))
                    {
                        _x -= displacement;
                    }
                    else
                    {
                        _x += displacement;
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Rover)obj);
        }

        protected bool Equals(Rover other)
        {
            return _direction == other._direction && _y == other._y && _x == other._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction, _y, _x);
        }

        public override string ToString()
        {
            return $"{nameof(_direction)}: {_direction}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }
    }

    internal record Direction(string Cardinality)
    {
        public Direction RotateLeft()
        {
            return Cardinality switch
            {
                "N" => new Direction("W"),
                "S" => new Direction("E"),
                "W" => new Direction("S"),
                _ => new Direction("N")
            };
        }
    }
}