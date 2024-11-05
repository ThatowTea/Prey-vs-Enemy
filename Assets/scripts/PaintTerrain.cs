using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaintTerrain : MonoBehaviour
{
    [System.Serializable]
    public class SplatHeights
    {
        public int textureIndex;
        public int startingHeight;
    }

    public SplatHeights[] splatHeights;//instance of the class Splat
    /// </summary>

    // Start is called before the first frame update


    //checks for 
    void Start()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;//terrain data stores infotmation abouit the detaulas

        float[, ,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];//alphamaplayers are textures

        for (int y = 0; y < terrainData.alphamapHeight; y++)
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                float terrainHeight = terrainData.GetHeight(y, x);

                float[] splat = new float[splatHeights.Length];
                //
                for (int i = 0; i < splatHeights.Length; i++)
                {
                    if (i == splatHeights.Length - 1 && terrainHeight >= splatHeights[i].startingHeight)
                    {
                        splat[i] = 1;
                    }

                    else if (terrainHeight >= splatHeights[i].startingHeight && terrainHeight <= splatHeights[i + 1].startingHeight)
                    {
                        splat[i] = 1;//set the opacity to 100 perc to make it visible
                    }//else opacity is 0 then we cant se

                }


                for (int j = 0; j < splatHeights.Length; j++)
                    splatmapData[x, y, j] = splat[j];//set those splat heights and stores them in the splatmapData
            }

        terrainData.SetAlphamaps(0, 0, splatmapData);

    }




    public void Copy()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;//terrain data stores infotmation abouit the detaulas

        float[, ,] splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];//alphamaplayers are textures

        for (int y = 0; y < terrainData.alphamapHeight; y++)
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                float terrainHeight = terrainData.GetHeight(y, x);

                float[] splat = new float[splatHeights.Length];
                //
                for (int i = 0; i < splatHeights.Length; i++)
                {
                    if (i == splatHeights.Length - 1 && terrainHeight >= splatHeights[i].startingHeight)
                    {
                        splat[i] = 1;
                    }

                    else if (terrainHeight >= splatHeights[i].startingHeight && terrainHeight <= splatHeights[i + 1].startingHeight)
                    {
                        splat[i] = 1;//set the opacity to 100 perc to make it visible
                    }//else opacity is 0 then we cant se

                }


                for (int j = 0; j < splatHeights.Length; j++)
                    splatmapData[x, y, j] = splat[j];//set those splat heights and stores them in the splatmapData
            }

        terrainData.SetAlphamaps(0, 0, splatmapData);

    }

}
