using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Use this for initialization
    void Start()
    {
        backbuffer = new byte[ysize*xsize*3];
        tex = new Texture2D(xsize, ysize, TextureFormat.RGB24, false);
        tex.filterMode = FilterMode.Point;
        quadRenderer.material.mainTexture = tex;
        

    }


    void setPixel(int x, int y, byte R, byte G, byte B)
    { 
        backbuffer[(y * xsize * 3) + x * 3] = R;
        backbuffer[(y*xsize*3)+3*x+1] = G;
        backbuffer[(y * xsize * 3) + 3 * x + 2] = B;

    }

    // Update is called once per frame
    void Update()
    {
       
        setPixel(coordinates.x, coordinates.y, colourR, colourG, colourB);
  //      setPixel(3, 2, 255, 255, 255)
    //    setPixel(6, 0, 0, 0, 255);


        //  backbuffer[0] = 255;
        //  backbuffer[1] = 0;
        // backbuffer[2] = 0;


        tex.LoadRawTextureData(backbuffer);
        tex.Apply(false);
    }
}
