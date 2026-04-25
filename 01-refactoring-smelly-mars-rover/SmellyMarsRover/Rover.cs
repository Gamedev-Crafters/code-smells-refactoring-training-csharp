using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private int _y;
        private int _x;
        private Direction _newDirection;

        public Rover(int x, int y, string direction)
        {
            _newDirection = new Direction(direction);
            _y = y;
            _x = x;
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                var rotateRight = command.Equals("r");
                var rotateLeft = command.Equals("l");

                if (rotateLeft)
                {
                    _newDirection = _newDirection.RotateLeft();
                }
                else if (rotateRight)
                {
                    _newDirection = _newDirection.RotateRight();
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

                    if (_newDirection.Cardinality.Equals("N"))
                    {
                        _y += displacement;
                    }
                    else if (_newDirection.Cardinality.Equals("S"))
                    {
                        _y -= displacement;
                    }
                    else if (_newDirection.Cardinality.Equals("W"))
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
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Rover)obj);
        }
        
        protected bool Equals(Rover other)
        {
            return _y == other._y && _x == other._x && Equals(_newDirection, other._newDirection);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_y, _x, _newDirection);
        }

        public override string ToString()
        {
            return $"{nameof(_y)}: {_y}, {nameof(_x)}: {_x}, {nameof(_newDirection)}: {_newDirection}";
        }
    }

    public record Direction(string Cardinality)
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

        public Direction RotateRight()
        {
            return Cardinality switch
            {
                "N" => new Direction("E"),
                "S" => new Direction("W"),
                "W" => new Direction("N"),
                _ => new Direction("S")
            };
        }
    }
}