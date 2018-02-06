using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class ReadTxt //:MonoBehaviour
{
    public static string[] ListFrame;
    public static string[] ListPoint;
    public static string[] OnePoint;
    public static List<float> CoordX;
    public static List<float> CoordZ;

    public ReadTxt()
	{

        string fileName = "Patterns/DifficileS.txt"; //62
        //string fileName = "Patterns/pattern99S.txt";
        ListFrame = File.ReadAllLines(fileName);
        
        //ListPoint = ListFrame[4].Split('-');
        
        /*TextReader reader;
		string fileName = "D:/Ecole/PRI/SpaceShooter/PRIVideoGames/test.txt";
        reader = new StreamReader(fileName);
        string floatString = reader.ReadLine();
        print(floatString);
        reader.Close();*/ 
	}
    public void GetPosition(int index)
    {
        CoordX = new List<float>();
        CoordZ = new List<float>();
        //ListPoint = ListFrame[index + 3].Split('-');
        ListPoint = ListFrame[index].Split('-');
        for (int i = 0; i < ListPoint.Length - 1; i++)
        {
            OnePoint = ListPoint[i].Split(' ');

            CoordX.Add(float.Parse(OnePoint[0]));
            CoordZ.Add(float.Parse(OnePoint[1]));
        }
    }
    public List<float> getCoordX()
    {
        return CoordX;
    }
    public List<float> getCoordZ()
    {
         return CoordZ;
    }
    public int getNbFrame()
    {
        return (ListFrame.Length - 3);
    }
}
