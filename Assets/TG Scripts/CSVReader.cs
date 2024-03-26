using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;
    public GameObject ReceiveUDPScript;
    public GameObject FileReaderScript;

    public int clipIndex;
    public string currClipCSV;


    [System.Serializable]

    public class Hazard
    {
        //Define data columns
        public string ClipName;
        public float Onset;
        public float Offset;
        public float Length;
        public int Location;

        public int xLocation;

        public int yLocation;
    }

    [System.Serializable]

    //create an array class
    public class HazardList
    {
        public Hazard[] hazard;
    }

    //declare an instance
    public HazardList myHazardList = new HazardList();
    
    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
        CurrentClipIndex();
    }

    void Update()
    {
        currClipCSV = GetCurrentClip();
        clipIndex = CurrentClipIndex();

    }
    void ReadCSV()
    {
        //Reads in text asset and splt string based on commas and carriage returns of csv file.
        string[] data = textAssetData.text.Split(new string [] { ",", "\n" }, StringSplitOptions.None);
        //each cell is new data point in string

        int tableSize = data.Length /7  - 1;
        
        myHazardList.hazard = new Hazard[tableSize];

        for (int i = 0; i < tableSize; i++ )
        {
            
            myHazardList.hazard[i] = new Hazard();
            
            myHazardList.hazard[i].ClipName = data[7 * (i + 1)];
            
            myHazardList.hazard[i].Onset = float.Parse(data[7 * (i + 1) + 1]);
            
            myHazardList.hazard[i].Offset = float.Parse(data[7 * (i + 1) + 2]);

            myHazardList.hazard[i].Length = float.Parse(data[7 * (i + 1) + 3]);
            
            myHazardList.hazard[i].Location = int.Parse(data[7 * (i + 1) + 4]);

            myHazardList.hazard[i].xLocation = int.Parse(data[7 * (i + 1) + 5]);

            myHazardList.hazard[i].yLocation = int.Parse(data[7 * (i + 1) + 6]);


        }


    }
    public string GetCurrentClip()
    {
        //return FileReaderScript.GetComponent<FileReader>().currentClip;
        
        return ReceiveUDPScript.GetComponent<ReceiveUDP>().receivedString;

    }

    public int CurrentClipIndex()
    {
        
        for (int i = 0; i < myHazardList.hazard.Length; i++)
        {
            string clipName = (myHazardList.hazard[i].ClipName); 

            if (clipName == GetCurrentClip())
            {
                clipIndex = i;
            }
        }
        return clipIndex;
        
    }


}
