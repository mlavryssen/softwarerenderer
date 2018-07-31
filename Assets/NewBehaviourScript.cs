using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Texture2D tex;
    public Renderer quadRenderer;
    public byte[] backbuffer;
    public int xsize;
    public int ysize;
    // Use this for initialization
    void Start () {
        backbuffer = new byte[64];
        tex = new Texture2D(xsize, ysize, TextureFormat.ARGB32, false);
        tex.filterMode = FilterMode.Point;
        quadRenderer.material.mainTexture = tex;






	}
	
	// Update is called once per frame
	void Update () {
      

        backbuffer[0] = 0;
        backbuffer[1] = 255;
        backbuffer[2] = 0;
        backbuffer[3] = 0;

        tex.LoadRawTextureData(backbuffer);
        tex.Apply(false);
    }
}
