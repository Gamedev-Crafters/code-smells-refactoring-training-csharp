using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private string _direction; 
        private int _y;
        private int _x;
        private Direction _directionNew;

        public Rover(int x, int y, string direction)
        {
            DirectionOld = direction; //primitive obsession
            _y = y; // Data clump (dos elementos que son parte de otra posible entidad, Vector)
            _x = x; // *
        }

        private string DirectionOld
        {
            get => _direction;
            set => _direction = value;
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("r")) // Complicated Boolean LO DE ABAJO
                {
                    // Rotate Rover // Comentario
                    if (DirectionOld.Equals("N"))
                    {
                        DirectionOld = "E";
                    }
                    else if (DirectionOld.Equals("S"))
                    {
                        DirectionOld = "W";
                    }
                    else if (DirectionOld.Equals("W"))
                    {
                        DirectionOld = "N";
                    }
                    else
                    {
                        DirectionOld = "S";
                    }
                }
                else if (command.Equals("l")) 
                {
                    // Rotate Rover Left
                    if (DirectionOld.Equals("N"))
                    {
                        DirectionOld = "W";
                    }
                    else if (DirectionOld.Equals("S"))
                    {
                        DirectionOld = "E";
                    }
                    else if (DirectionOld.Equals("W"))
                    {
                        DirectionOld = "S";
                    }
                    else
                    {
                        DirectionOld = "N";
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

                    if (DirectionOld.Equals("N"))
                    {
                        _y += displacement;
                    }
                    else if (DirectionOld.Equals("S"))
                    {
                        _y -= displacement;
                    }
                    else if (DirectionOld.Equals("W"))
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
            return DirectionOld == other.DirectionOld && _y == other._y && _x == other._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DirectionOld, _y, _x);
        }

        public override string ToString()
        {
            return $"{nameof(_direction)}: {DirectionOld}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }
    }

    internal record Direction
    {
    }
}