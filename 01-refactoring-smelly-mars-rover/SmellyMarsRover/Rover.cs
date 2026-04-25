using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private string _direction;
        private int _y;
        private int _x;
        private Direction _newDirection;

        public Rover(int x, int y, string direction)
        {
            Direction = direction;
            _y = y;
            _x = x;
        }

        public string Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                _newDirection = new Direction(value);
            }
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
                    // Rotate Rover Left
                    if (Direction.Equals("N"))
                    {
                        Direction = "W";
                    }
                    else if (Direction.Equals("S"))
                    {
                        Direction = "E";
                    }
                    else if (Direction.Equals("W"))
                    {
                        Direction = "S";
                    }
                    else
                    {
                        Direction = "N";
                    }
                }
                else if (rotateRight)
                {
                    // Rotate Rover Right
                    if (Direction.Equals("N"))
                    {
                        Direction = "E";
                    }
                    else if (Direction.Equals("S"))
                    {
                        Direction = "W";
                    }
                    else if (Direction.Equals("W"))
                    {
                        Direction = "N";
                    }
                    else
                    {
                        Direction = "S";
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

                    if (Direction.Equals("N"))
                    {
                        _y += displacement;
                    }
                    else if (Direction.Equals("S"))
                    {
                        _y -= displacement;
                    }
                    else if (Direction.Equals("W"))
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
            return $"{nameof(_direction)}: {_direction}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }
    }

    public record Direction()
    {
        private readonly string _direction;

        public Direction(string direction) : this()
        {
            _direction = direction;
        }
    }
}