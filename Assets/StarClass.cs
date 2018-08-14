using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClass {

    public Vector3 starPosition;
    public float zStartingPoint;

    public StarClass(Vector3 starPosition)
    {
        this.starPosition = starPosition;
        zStartingPoint = starPosition.z;
    }

    public void Update()
    {

        starPosition.z-= 0.1f;

        if (starPosition.z < 0)
        {
            starPosition.z = zStartingPoint;
        }

    }
}
