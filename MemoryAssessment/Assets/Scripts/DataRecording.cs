using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataRecording : MonoBehaviour {

    public bool writeToFileProcessedData;
    bool isFileCreatedProcessedData = false;
    string fileName;
    public string testSubjectName;
    StreamWriter writer;

    // Use this for initialization
    void Start () {

        creatFileToWrite();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void creatFileToWrite()
    {
        if (writeToFileProcessedData)
        {
            // if file was not created create the file then next time start writing to it. 
            if (!isFileCreatedProcessedData)
            {
                // create a file to write data to 
                try
                {
                    fileName = testSubjectName + "_Report_" + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
                    writer = new StreamWriter("Assets/Output_files/" + fileName, true);
                    isFileCreatedProcessedData = true;

                    writer.WriteLine("Room_number,passcode,entered_passcode");
                }
                catch (IOException e)
                {
                    print("File writing exception message: " + e.Message);
                }
            }
        }
    }

    public void writeToFile(string outputLine)
    {
        if (isFileCreatedProcessedData)
        {
            writer.WriteLine(outputLine);           
        }
    }

    private void OnDestroy()
    {
        if (isFileCreatedProcessedData)
        {           
            writer.Close();
        }
    }

}
