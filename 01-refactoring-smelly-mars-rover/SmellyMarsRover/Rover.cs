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
            _directionNew = new Direction(direction); //primitive obsession
            _y = y; // Data clump (dos elementos que son parte de otra posible entidad, Vector)
            _x = x; // *
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("r")) // Complicated Boolean LO DE ABAJO
                {
                    // Rotate Rover // Comentario
                    if (_directionNew.Cardinality.Equals("N"))
                    {
                        _directionNew = new Direction("E");
                    }
                    else if (_directionNew.Cardinality.Equals("S"))
                    {
                        _directionNew = new Direction("W");
                    }
                    else if (_directionNew.Cardinality.Equals("W"))
                    {
                        _directionNew = new Direction("N");
                    }
                    else
                    {
                        _directionNew = new Direction("S");
                    }
                }
                else if (command.Equals("l")) 
                {
                    // Rotate Rover Left
                    if (_directionNew.Cardinality.Equals("N"))
                    {
                        _directionNew = new Direction("W");
                    }
                    else if (_directionNew.Cardinality.Equals("S"))
                    {
                        _directionNew = new Direction("E");
                    }
                    else if (_directionNew.Cardinality.Equals("W"))
                    {
                        _directionNew = new Direction("S");
                    }
                    else
                    {
                        _directionNew = new Direction("N");
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

                    if (_directionNew.Cardinality.Equals("N"))
                    {
                        _y += displacement;
                    }
                    else if (_directionNew.Cardinality.Equals("S"))
                    {
                        _y -= displacement;
                    }
                    else if (_directionNew.Cardinality.Equals("W"))
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
            return _directionNew.Cardinality == other._directionNew.Cardinality && _y == other._y && _x == other._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_directionNew.Cardinality, _y, _x);
        }

        public override string ToString()
        {
            return $"{"_direction"}: {_directionNew.Cardinality}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }
    }

    internal record Direction(string Cardinality)
    {
    }
}