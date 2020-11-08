using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTerraiin : MonoBehaviour
{
    Terrain testTerrain;

    private System.Random random;
    public float[,] Genes;
    int RowSize = 300;
    int ColSize = 300;
    int depth = 5;

    public int verticesNum;

    float maxNumHeight = 100;
    float height;
    float rangeX = 30f, rangeY = 30f; // 랜덤

    float center_difference;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        Genes = new float[RowSize, ColSize];
        GetRandomInt();

        maxNumHeight = 30 * (float)random.NextDouble();
        //testTerrain.terrainData.alphamapHeight
        //List<float> myVertices = new List<float>();
        //foreach (Vector3 vertex in meshFilter.mesh.vertices) {
        //    myVertices.Add(vertex);
        //}
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void GetRandomInt()
    {
        int x = 0, y = 0;
        //for(int v=0;v< verticesNum; v++)
        //{
        //    i = random.Next(0,RowSize-1);
        //    j = random.Next(0,ColSize-1);
        //    Genes[i, j] = (float)random.NextDouble();
        //}

        // 0.5로 초기화 전체
        for (int i = 0; i < RowSize; i++)
        {
            for (int j = 0; j < ColSize; j++)
            {
                Genes[i, j] = 0.5f;
            }
        }


       //maxNumHeight = 1;
        double newHeight;
        for (int v = 0; v < maxNumHeight; v++)
        {
            x = random.Next(0, RowSize - 1);  //x
            y = random.Next(0, ColSize - 1); //y

            rangeX = random.Next(30, 100);
            rangeY = random.Next(30, 100);
            //while (true)
            //{
            //    if (Genes[x, y] != 0)
            //    {
            //        x = random.Next(0, RowSize - 1);  //x
            //        y = random.Next(0, ColSize - 1);
            //    }
            //    else break;
            //}

            //Debug.Log("---------------"+v+ "---------------");

            center_difference = (float)random.NextDouble()-0.5f; //랜덤``
                                                                 //  center_difference *= 0.3f;
                                                                 // Genes[x, y] = Genes[x, y] * 2f - 1f;

            //Debug.Log(Genes[x, y]);
            Debug.Log("center: " + x + ", " + y);
            Debug.Log("range:" + rangeX + ", " + rangeY);

            for (float i = -rangeX / 2; i <= rangeX / 2; i++)
            {
                for (float j = -rangeY / 2; j <= rangeY / 2; j++)
                {
                    int tmpX = Mathf.FloorToInt(x + i);
                    int tmpY = Mathf.FloorToInt(y + j);
                    if ((tmpX >= RowSize || tmpX < 0) || (tmpY >= ColSize || tmpY < 0)) break;

                    newHeight = center_difference *Mathf.Clamp01( 1 - Mathf.Sqrt(Mathf.Pow((x - tmpX) / rangeX * 2, 2) + Mathf.Pow((y - tmpY) / rangeY * 2, 2)));


                    //Debug.Log("before 1- :" + Mathf.Sqrt(Mathf.Pow((x - tmpX) / rangeX * 2, 2) + Mathf.Pow((y - tmpY) / rangeY * 2, 2)));
                    //Debug.Log("(" + tmpX + ", " + tmpY + "):"  +"="+ newHeight);
                    Genes[tmpX, tmpY] += ((float)newHeight);
                }
            }

        }

    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = RowSize + 1;

        terrainData.size = new Vector3(RowSize, depth, ColSize); //width, depth,height
        terrainData.SetHeights(0, 0, Genes);
        return terrainData;
    }
}
