using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class green : MonoBehaviour
{
    private System.Random random;
    public float[,] Genes;
    int RowSize;
    int ColSize;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        RowSize = 302;
        ColSize = 302;
        Genes = new float[RowSize, ColSize];
        GetRandomInt();
        /*
        do
        {
            GetRandomInt();
            CheckHeight();
        } while (!CheckHeight());
        
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetRandomInt()
    {
        for(int i=0; i<RowSize; i++)
        {
            for(int j=0; j<ColSize; j++)
            {
                if(i==0 || j==0 || i==RowSize-1 || j == ColSize - 1)
                {
                    Genes[i, j]=0f;
                }
                else
                {
                    Genes[i, j] = (float)random.NextDouble();
                }
                
                Debug.Log(Genes[i, j]);
            }
        }
    }
    /*
    private bool CheckHeight()
    {
        for(int i=1; i<RowSize-1; i++)
        {
            for(int j=1; j<ColSize-1; j++)
            {
                for(int k=i-1; k<=i+1; k++)
                {
                    for(int l=j-1; l<=j+1; l++)
                    {
                        
                            if (Mathf.Abs(Genes[i, j] - Genes[k, l]) > 0.4)
                            {
                                return false;
                            }
                    }
                }
            }
        }
        return true;
    }
    */
    
}
