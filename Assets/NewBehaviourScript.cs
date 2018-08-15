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
    public float FoV;
    public int offsetX;
    public int offsetY;
    public int numberOfStars;

    public List<StarClass> Stars;
    // Use this for initialization
    void Start()
    {
        Stars = new List<StarClass>(numberOfStars);
        backbuffer = new byte[ysize * xsize * 3];
        tex = new Texture2D(xsize, ysize, TextureFormat.RGB24, false);
        tex.filterMode = FilterMode.Point;
        quadRenderer.material.mainTexture = tex;
        offsetX = xsize / 2;
        offsetY = ysize / 2;




        for (int i = 0; i < numberOfStars; i++)
        {
            StarClass starClass = new StarClass(new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(10, 100)));
            Stars.Add(starClass);


        }
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

    // Update is called once per frame
    void Update()
    {
        ClearBuffer();
        foreach (StarClass item in Stars)
        {

            

            item.Update();

            setPixel((int)(item.starPosition.x / (item.starPosition.z * FoV) + offsetX), (int)(item.starPosition.y / (item.starPosition.z * FoV)+ offsetY), (byte)(colourR - ((item.starPosition.z/100) * colourR)), (byte)(colourG - ((item.starPosition.z / 100) * colourG)), (byte)(colourB - ((item.starPosition.z / 100)) * colourB));
      
        }



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
