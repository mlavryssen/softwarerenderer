using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClass {

    public Vector3 LocalPosition;
    public float zStartingPoint;

    public StarClass(Vector3 localPosition)
    {
        this.LocalPosition = localPosition;
        zStartingPoint = localPosition.z;
    }
}
