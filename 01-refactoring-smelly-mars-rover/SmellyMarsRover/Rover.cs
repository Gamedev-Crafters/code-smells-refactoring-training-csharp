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
                    if (_direction.Cardinality.Equals("N"))
                    {
                        _direction = new Direction("E");
                    }
                    else if (_direction.Cardinality.Equals("S"))
                    {
                        _direction = new Direction("W");
                    }
                    else if (_direction.Cardinality.Equals("W"))
                    {
                        _direction = new Direction("N");
                    }
                    else
                    {
                        _direction = new Direction("S");
                    }
                }
                else if (command.Equals("l")) 
                {
                    // Rotate Rover Left
                    if (_direction.Cardinality.Equals("N"))
                    {
                        _direction = new Direction("W");
                    }
                    else if (_direction.Cardinality.Equals("S"))
                    {
                        _direction = new Direction("E");
                    }
                    else if (_direction.Cardinality.Equals("W"))
                    {
                        _direction = new Direction("S");
                    }
                    else
                    {
                        _direction = new Direction("N");
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
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rover)obj);
        }

        protected bool Equals(Rover other)
        {
            return _direction.Cardinality == other._direction.Cardinality && _y == other._y && _x == other._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction.Cardinality, _y, _x);
        }

        public override string ToString()
        {
            return $"{"_direction"}: {_direction.Cardinality}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }
    }

    internal record Direction(string Cardinality)
    {
    }
}