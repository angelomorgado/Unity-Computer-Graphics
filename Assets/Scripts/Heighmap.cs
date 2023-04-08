namespace Heightmap_namespace
{
    using UnityEngine;   
    public class Heightmap
    {
        // Heightmap variables
        private int seed = 0;
        private FastNoiseLite.NoiseType type = FastNoiseLite.NoiseType.OpenSimplex2;
        private FastNoiseLite.FractalType fractalType = FastNoiseLite.FractalType.FBm;
        private int octaves = 8;
        private float frequency = 0.005f;
        private float lacunarity = 0.80f;
        private float gain = 0.40f;

        // Texture variables
        private int width = 256;
        private int height = 256;
        private float scale = 1f;
        private float shift = 0.0f;
        private float offsetX = 0f;
        private float offsetY = 0f;

        private FastNoiseLite noise;
        private Texture2D tex;


        public Heightmap()
        {
            noise = new FastNoiseLite();
            setNoiseParameters();
        }

        public void setNoiseParameters()
        {
            noise.SetSeed(seed);
            noise.SetNoiseType(type);
            noise.SetFrequency(frequency);
            noise.SetFractalType(fractalType);
            noise.SetFractalLacunarity(lacunarity);
            noise.SetFractalOctaves(octaves);
            noise.SetFractalGain(gain);
        }

        public void GenerateTexture()
        {
            tex = new Texture2D(width, height);

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    int xCoord = (int)(x * scale + offsetX);
                    int yCoord = (int)(y * scale + offsetY);

                    float v = noise.GetNoise(xCoord, yCoord) + shift;
                    Color c = new Color(v, v, v, 1);
                    tex.SetPixel(x, y, c);
                }
            }

            NormalizeTexture();
        }

        private void NormalizeTexture()
        {
            float min = 0;
            float max = 0;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    float v = tex.GetPixel(x, y).r;
                    if(v < min)
                    {
                        min = v;
                    }
                    if(v > max)
                    {
                        max = v;
                    }
                }
            }

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    float v = tex.GetPixel(x, y).r;
                    v = (v - min) / (max - min);
                    Color c = new Color(v, v, v, 1);
                    tex.SetPixel(x, y, c);
                }
            }
        }

        public Texture2D getTexture()
        {
            return tex;
        }

        public int getHeight()
        {
            return height;
        }

        public float[,] getHeights()
        {
            float[,] heights = new float[width, height];

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    heights[x, y] = tex.GetPixel(x, y).r;
                }
            }

            return heights;
        }

        public void setSeed(int seed)
        {
            this.seed = seed;
        }

        public void setType(FastNoiseLite.NoiseType type)
        {
            this.type = type;
        }

        public void setFractalType(FastNoiseLite.FractalType fractalType)
        {
            this.fractalType = fractalType;
        }

        public void setOctaves(int octaves)
        {
            this.octaves = octaves;
        }

        public void setFrequency(float frequency)
        {
            this.frequency = frequency;
        }

        public void setLacunarity(float lacunarity)
        {
            this.lacunarity = lacunarity;
        }

        public void setGain(float gain)
        {
            this.gain = gain;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public void setScale(float scale)
        {
            this.scale = scale;
        }

        public void setShift(float shift)
        {
            this.shift = shift;
        }

        public void setOffsetX(float offsetX)
        {
            this.offsetX = offsetX;
        }

        public void setOffsetY(float offsetY)
        {
            this.offsetY = offsetY;
        }

        public int getWidth()
        {
            return width;
        }
    }
}