using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadMatrix : MonoBehaviour 
{
    private static int nbFrame;
    private static Vector3 playerPositionInit;
    private static char[, ,] matrixList;
    private static List<float> coordX;
    private static List<float> coordZ;

    public ReadMatrix()
    {
        string fileName = "TirSimpleUni/50TirCC.txt";

        string[] contentFile = File.ReadAllLines(fileName);
        string[] infoMatrix = contentFile[0].Split(' ');

        playerPositionInit = new Vector3(float.Parse(infoMatrix[1]), -7, float.Parse(infoMatrix[2]));
        nbFrame = int.Parse(infoMatrix[0]);


        matrixList = new char[22, 22, nbFrame];
        coordX = new List<float>();
        coordZ = new List<float>();

        int contentIndex = 0;
        char[] bouh = contentFile[1].ToCharArray();
        
        for (int f = 0; f < nbFrame-1; f++)
        {
            for (int z = 0; z < 21; z++)
            {
                for (int x = 0; x < 21; x++)
                {
                    matrixList[x,z,f] = bouh[contentIndex];
                    contentIndex++;
                }
            }
        }

        
    }

    public void getPosition(int index)
    {
        coordX = new List<float>();
        coordZ = new List<float>();
        for (int x = 0; x < 21; x++)
        {
            for (int z = 0; z < 21; z++)
            {
                if (matrixList[x,z,index] == '1')
                {
                    coordX.Add(x);
                    coordZ.Add(z);
                }
            }
        }
    }

    public List<float> getCoordX()
    {
        return coordX;
    }

    public List<float> getCoordZ()
    {
        return coordZ;
    }

    public int getNbFrame()
    {
        return nbFrame;
    }

    public Vector3 getPlayerPositionInit()
    {
        return playerPositionInit;
    }
}
