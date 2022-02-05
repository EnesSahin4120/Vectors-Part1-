using System.Collections.Generic;
using UnityEngine;

public class VectorsTest : MonoBehaviour
{
    [Header("Orthonormalization Part")]
    [SerializeField] private Vector3 firstVector;
    [SerializeField] private Vector3 secondVector;
    [SerializeField] private Vector3 thirdVector;

    void Start()
    {  
        List<Coordinates> orthogonalization=Mathematics.Orthogonalization(new Coordinates(firstVector.x, firstVector.y, firstVector.z),
            new Coordinates(secondVector.x, secondVector.y, secondVector.z),
            new Coordinates(thirdVector.x, thirdVector.y, thirdVector.z));

        List<Coordinates> orthonormalization= Mathematics.Orthonormalization(orthogonalization[0], orthogonalization[1], orthogonalization[2]);

        Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(orthonormalization[0].x, orthonormalization[0].y, orthonormalization[0].z), Color.red, Mathf.Infinity);
        Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(orthonormalization[1].x, orthonormalization[1].y, orthonormalization[1].z), Color.green, Mathf.Infinity);
        Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(orthonormalization[2].x, orthonormalization[2].y, orthonormalization[2].z), Color.yellow, Mathf.Infinity);

    }
}
