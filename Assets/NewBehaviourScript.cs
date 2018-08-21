using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Environments;
using UnityEngine;
using UnityEngine.Experimental.XR;
using Mesh = Michelle.Mesh;

namespace Michelle
{



    public class NewBehaviourScript : MonoBehaviour
    {

        public Texture2D tex;
        public Renderer quadRenderer;
        public byte[] backbuffer;
        public int xsize;
        public int ysize;
        public Vector2Int coordinates;
        public byte colourR;
        public byte colourG;
        public byte colourB;
        public float FoV;
        public int offsetX;
        public int offsetY;
        public int numberOfStars;
        public Mesh MyMesh;
        public float speed;

    

        // Use this for initialization
        void Start()
        {
            backbuffer = new byte[ysize * xsize * 3];
            tex = new Texture2D(xsize, ysize, TextureFormat.RGB24, false);
            tex.filterMode = FilterMode.Point;
            quadRenderer.material.mainTexture = tex;
            offsetX = xsize / 2;
            offsetY = ysize / 2;



            MyMesh = new Mesh(new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000)));

            for (int i = 0; i < numberOfStars; i++)
            {
                StarClass starClass = new StarClass(new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000),
                    Random.Range(10, 100)));
                
                MyMesh.Vertexes.Add(starClass);

                

            }
            MyMesh.Position = new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
            MyMesh.Vertexes[0].LocalPosition = new Vector3(-0.5f, 0.5f, 0.5f);
            MyMesh.Vertexes[1].LocalPosition = new Vector3(-0.5f, 0.5f, -0.5f);
            MyMesh.Vertexes[2].LocalPosition = new Vector3(0.5f, 0.5f, 0.5f);
            MyMesh.Vertexes[3].LocalPosition = new Vector3(0.5f, 0.5f, -0.5f);
            MyMesh.Vertexes[4].LocalPosition = new Vector3(-0.5f, -0.5f, 0.5f);
            MyMesh.Vertexes[5].LocalPosition = new Vector3(-0.5f, -0.5f, -0.5f);
            MyMesh.Vertexes[6].LocalPosition = new Vector3(0.5f, -0.5f, 0.5f);
            MyMesh.Vertexes[7].LocalPosition = new Vector3(0.5f, -0.5f, -0.5f);



        }





        void setPixel(int x, int y, byte R, byte G, byte B)
        {
            //this checks if the pixels would be outside of the bounds
            if (x < xsize && y < ysize && x >= 0 && y >= 0)
            {
                //if they aren't, feel free to draw them
                backbuffer[(y * xsize * 3) + x * 3] = R;
                backbuffer[(y * xsize * 3) + 3 * x + 1] = G;
                backbuffer[(y * xsize * 3) + 3 * x + 2] = B;
            }

        }

        void ClearBuffer()
        {
            for (int i = 0; i < backbuffer.Length; i++)
            {
                backbuffer[i] = 0;
            }
        }

        void Update()
        { 
    
            ClearBuffer();


            MyMesh.Position.z -= speed;

                if (MyMesh.Position.z < 0)
                {
                    MyMesh.Position.z = MyMesh.zStartingPoint;
                }




            foreach (StarClass item in MyMesh.Vertexes)
            {
                Vector3 WorldPosition = item.LocalPosition + MyMesh.Position;

                setPixel((int)(item.LocalPosition.x / (item.LocalPosition.z * FoV) + offsetX),
                   (int)(item.LocalPosition.y / (item.LocalPosition.z * FoV) + offsetY),
                    (byte)(colourR - ((item.LocalPosition.z / 100) * colourR)),
                    (byte)(colourG - ((item.LocalPosition.z / 100) * colourG)),
                    (byte)(colourB - ((item.LocalPosition.z / 100)) * colourB));
            }
            tex.LoadRawTextureData(backbuffer);
            tex.Apply(false);

        }




        // Update is called once per frame
        //void UpdateStarDemo()
        //{
           // ClearBuffer();
//            foreach (StarClass item in Stars)
//            {
//
//
//
//                item.Update();
//
//                setPixel((int)(item.LocalPosition.x / (item.LocalPosition.z * FoV) + offsetX),
//                    (int)(item.LocalPosition.y / (item.LocalPosition.z * FoV) + offsetY),
//                    (byte)(colourR - ((item.LocalPosition.z / 100) * colourR)),
//                    (byte)(colourG - ((item.LocalPosition.z / 100) * colourG)),
//                    (byte)(colourB - ((item.LocalPosition.z / 100)) * colourB));
//
//            }
//


            //for (int i = 0; i < backbuffer.Length; i++)
            //{
            //    setPixel(Random.Range(0, xsize), Random.Range(0, ysize), (byte)Random.Range(0,255), (byte)Random.Range(0,255), (byte)Random.Range(0,255));
            // }


            //      setPixel(3, 2, 255, 255, 255)
            //    setPixel(6, 0, 0, 0, 255);


            //  backbuffer[0] = 255;
            //  backbuffer[1] = 0;
            // backbuffer[2] = 0;

            //upload texture
            tex.LoadRawTextureData(backbuffer);
            tex.Apply(false);
        }

    }
}
