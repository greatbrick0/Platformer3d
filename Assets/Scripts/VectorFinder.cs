using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFinder
{
    public enum Direction {
        Upwards,
        Downwards,
        Left,
        DoubleUp,
        DoubleForward,
        JumpForward
    }

    [HideInInspector]
    public Direction direction = Direction.DoubleForward;

    public Vector3 FindVector()
    {
        switch (direction)
        {
            case Direction.Upwards:
                return new Vector3(0, 1, 0);
            case Direction.Downwards:
                return new Vector3(0, -1, 0);
            case Direction.Left:
                return new Vector3(-1, 0, 0);
            case Direction.DoubleUp:
                return new Vector3(0, 2, 0);
            case Direction.DoubleForward:
                return new Vector3(0, 0, 2);
            case Direction.JumpForward:
                return new Vector3(0, 1, 1);
            default:
                return new Vector3(0, 0, 0);
        }
    }
}
