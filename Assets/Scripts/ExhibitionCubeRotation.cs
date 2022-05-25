using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhibitionCubeRotation : MonoBehaviour
{
    [SerializeField] GameObject exhibitionCube;
    public float xAngle, yAngle, zAngle;

    void Start()
    {
        
    }

    
    void Update()
    {
        exhibitionCube.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    }
}
