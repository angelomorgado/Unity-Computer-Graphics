using UnityEngine;
using Heightmap_namespace;

public class GenerateHeightmap : MonoBehaviour
{
    private FastNoiseLite noise;

    // Heightmap variables
    public int seed = 0;
    public FastNoiseLite.NoiseType type = FastNoiseLite.NoiseType.OpenSimplex2;
    public FastNoiseLite.FractalType fractalType = FastNoiseLite.FractalType.FBm;
    public int octaves = 8;
    public float frequency = 0.005f;
    public float lacunarity = 0.80f;
    public float gain = 0.40f;

    // Texture variables
    public int width = 256;
    public int height = 256;
    public float scale = 1f;
    public float shift = 0.0f;
    public float offsetX = 0f;
    public float offsetY = 0f;

    private Heightmap heightmap;
    private Texture2D tex;

    private void setHeightmapVariables()
    {
        heightmap.setSeed(seed);
        heightmap.setType(type);
        heightmap.setFractalType(fractalType);
        heightmap.setOctaves(octaves);
        heightmap.setFrequency(frequency);
        heightmap.setLacunarity(lacunarity);
        heightmap.setGain(gain);
        
        heightmap.setWidth(width);
        heightmap.setHeight(height);
        heightmap.setScale(scale);
        heightmap.setShift(shift);
        heightmap.setOffsetX(offsetX);
        heightmap.setOffsetY(offsetY);
    }

    // Start is called before the first frame update
    void Start()
    {
        heightmap = new Heightmap();
        setHeightmapVariables();
        heightmap.GenerateTexture();
        tex = heightmap.getTexture();
        tex.Apply();
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            setHeightmapVariables();
            heightmap.setNoiseParameters();
            heightmap.GenerateTexture();
            tex = heightmap.getTexture();
            tex.Apply();
            GetComponent<Renderer>().material.mainTexture = tex;
        }
    }
}