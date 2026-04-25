using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private int _y;
        private int _x;
        private Direction _directionNew;

        public Rover(int x, int y, string direction)
        {
            Direction = direction;
            _y = y;
            _x = x;
        }

        private string Direction
        {
            get => _directionNew.Cardinality;
            set
            {
                _directionNew = new Direction(value);
            }
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    // Rotate Rover Left
                    if (Direction.Equals("N"))
                        Direction = "W";
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
                else if (command.Equals("r"))
                {
                    // Rotate Rover Right
                    if (Direction.Equals("N"))
                    {
                        if (true)
                        {
                            Direction = "E";
                        }
                    }
                    else if (Direction.Equals("S"))
                    {
                        if (true)
                        {
                            Direction = "W";
                        }
                    }
                    else if (Direction.Equals("W"))
                    {
                        if (true)
                        {
                            Direction = "N";
                        }
                    }
                    else
                    {
                        if (true)
                        {
                            Direction = "S";
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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rover)obj);
        }

        protected bool Equals(Rover other)
        {
            return _directionNew == other._directionNew && _y == other._y && _x == other._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_directionNew, _y, _x);
        }

        public override string ToString()
        {
            return $"{nameof(_directionNew)}: {_directionNew}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }
    }

    internal record Direction(string Cardinality);
}