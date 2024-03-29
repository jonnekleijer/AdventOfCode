﻿namespace Day9;

class Position : IEquatable<Position>
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public Direction? KnotMove(Position tail)
    {
        var dx = X - tail.X;
        var dy = Y - tail.Y;

        ValidateInput(dx, dy);

        if (-1 <= dx && dx <= 1 && -1 <= dy && dy <= 1)
        {
            return null;
        }

        if (dy == 2)
        {
            return MoveUp(dx);
        }

        if (dy == -2)
        {
            return MoveDown(dx);
        }

        if (dx == 2)
        {
            return MoveRight(dy);
        }

        if (dx == -2)
        {
            return MoveLeft(dy);
        }

        throw new ArgumentException("Condition should not occur.");
    }

    private static Direction MoveUp(int dx) => dx switch
    {
        -2 => Direction.UL,
        -1 => Direction.UL,
        0 => Direction.U,
        1 => Direction.UR,
        2 => Direction.UR,
        _ => throw new ArgumentException("Not supported."),
    };

    private static Direction MoveDown(int dx) => dx switch
    {
        -2 => Direction.DL,
        -1 => Direction.DL,
        0 => Direction.D,
        1 => Direction.DR,
        2 => Direction.DR,
        _ => throw new ArgumentException("Not supported."),
    };

    private static Direction MoveRight(int dy) => dy switch
    {
        -2 => Direction.DR,
        -1 => Direction.DR,
        0 => Direction.R,
        1 => Direction.UR,
        2 => Direction.UR,
        _ => throw new ArgumentException("Not supported."),
    };

    private static Direction MoveLeft(int dy) => dy switch
    {
        -2 => Direction.DL,
        -1 => Direction.DL,
        0 => Direction.L,
        1 => Direction.UL,
        2 => Direction.UL,
        _ => throw new ArgumentException("Not supported."),
    };

    private static void ValidateInput(int dx, int dy)
    {
        if (-2 > dx || dx > 2)
        {
            throw new ArgumentException($"Unexpected large distance.");
        }

        if (-2 > dy || dy > 2)
        {
            throw new ArgumentException($"Unexpected large distance.");
        }
    }

    public bool Equals(Position other)
    {
        return other.X == X && other.Y == Y;
    }

    public override bool Equals(object other)
    {
        var mod = other as Position;
        if (mod != null)
            return Equals(mod);
        return false;
    }

    public override string ToString()
    {
        return $"Position({X}, {Y})";
    }
}
