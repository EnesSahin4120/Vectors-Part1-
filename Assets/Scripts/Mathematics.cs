using System.Collections.Generic;
using UnityEngine;

public class Mathematics : MonoBehaviour
{
    static public float Square(float grade)
    {
        return grade * grade;
    }

    static public float Distance(Coordinates coord1,Coordinates coord2)
    {
        float diffSquared = Square(coord1.x - coord2.x) +
            Square(coord1.y - coord2.y) +
            Square(coord1.z - coord2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float VectorLength(Coordinates vector)
    {
        float length = Distance(new Coordinates(0, 0, 0), vector);
        return length;
    }

    static public Coordinates Normalize(Coordinates vector)
    {
        float length = VectorLength(vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Dot(Coordinates vector1,Coordinates vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public Coordinates Projection(Coordinates vector1,Coordinates vector2)
    {
        float numeratorPart = Dot(vector1, vector2);
        float vector2Length = VectorLength(vector2);
        float denominatorPart = Square(vector2Length);
        Coordinates resultCoordinate = new Coordinates(vector2.x * (numeratorPart / denominatorPart), vector2.y * (numeratorPart / denominatorPart), vector2.z * (numeratorPart / denominatorPart));
   
        return resultCoordinate;
    }

    static public List<Coordinates> Orthogonalization(Coordinates vector1,Coordinates vector2,Coordinates vector3)
    {
        Coordinates orthogonalization1 = vector1;

        Coordinates orthogonalization2 = new Coordinates(vector2.x - Projection(vector2, orthogonalization1).x,
            vector2.y - Projection(vector2, orthogonalization1).y,
            vector2.z - Projection(vector2, orthogonalization1).z);

        Coordinates orthogonalization3 = new Coordinates(vector3.x - Projection(vector3, orthogonalization1).x - Projection(vector3, orthogonalization2).x,
            vector3.y - Projection(vector3, orthogonalization1).y - Projection(vector3, orthogonalization2).y,
            vector3.z - Projection(vector3, orthogonalization1).z - Projection(vector3, orthogonalization2).z);

        List<Coordinates> resultCoordinates = new List<Coordinates>();
        resultCoordinates.Add(orthogonalization1);
        resultCoordinates.Add(orthogonalization2);
        resultCoordinates.Add(orthogonalization3);

        return resultCoordinates;
    } 

    static public List<Coordinates> Orthonormalization(Coordinates vector1,Coordinates vector2,Coordinates vector3)
    {
        Coordinates orthonormalization1 = new Coordinates(vector1.x / VectorLength(vector1), vector1.y / VectorLength(vector1), vector1.z / VectorLength(vector1));
        Coordinates orthonormalization2 = new Coordinates(vector2.x / VectorLength(vector2), vector2.y / VectorLength(vector2), vector2.z / VectorLength(vector2));
        Coordinates orthonormalization3 = new Coordinates(vector3.x / VectorLength(vector3), vector3.y / VectorLength(vector3), vector3.z / VectorLength(vector3));

        List<Coordinates> resultCoordinates = new List<Coordinates>();
        resultCoordinates.Add(orthonormalization1);
        resultCoordinates.Add(orthonormalization2);
        resultCoordinates.Add(orthonormalization3);

        return resultCoordinates;
    }
}
