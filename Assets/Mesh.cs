using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michelle
{

    public class Mesh
    {
        public Vector3 LocalPosition;
        public float zStartingPoint;
        public List<StarClass> Vertexes;

        public Vector3 Position;



        // Constructor
        public Mesh(Vector3 localPosition)
        {
            Vertexes = new List<StarClass>();
            this.LocalPosition = localPosition;
            zStartingPoint = localPosition.z;
        }

    }

}
