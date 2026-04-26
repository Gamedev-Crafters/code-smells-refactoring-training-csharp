using System;

namespace SmellyMarsRover;

internal record Direction(string Cardinality)
{
    public Direction RotateRight()
    {
        return Cardinality switch
        {
            "N" => new Direction("E"),
            "S" => new Direction("W"),
            "W" => new Direction("N"),
            "E" => new Direction("S"),
            _ => throw new Exception("Invalid direction")
        };
    }
}