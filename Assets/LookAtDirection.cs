using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDirection : MonoBehaviour
{
    public Transform reference;
    public Direction forward = Direction.FORWARD;
    public Direction up = Direction.UP;

    public enum Direction
    {
        FORWARD,
        BACKWARD,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardLook = SelectDirection(forward);
        Vector3 upLook = SelectDirection(up);
        

        transform.localRotation = Quaternion.LookRotation(forwardLook, upLook);
    }

    private Vector3 SelectDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.FORWARD:
                return reference.forward;
            case Direction.BACKWARD:
                return -reference.forward;
            case Direction.LEFT:
                return -reference.right;
            case Direction.RIGHT:
                return reference.right;
            case Direction.UP:
                return reference.up;
            case Direction.DOWN:
                return -reference.up;
            default:
                return reference.forward;
        }
    }
}
