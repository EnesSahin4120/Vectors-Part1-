using UnityEngine;

public class Coordinates : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public Coordinates(float _x,float _y)
    {
        x = _x;
        y = _y;
        z = -1;
    }

    public Coordinates(float _x, float _y,float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public Coordinates(Vector3 vectorPosition)
    {
        x = vectorPosition.x;
        y = vectorPosition.y;
        z = vectorPosition.z;
    }
}
