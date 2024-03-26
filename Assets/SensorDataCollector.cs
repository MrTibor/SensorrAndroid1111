using UnityEngine;
using System.IO;

public class SensorDataCollector : MonoBehaviour
{
    private StreamWriter fileWriter;
    private bool isCollectingData = false;

    void Start()
    {
        Input.gyro.enabled = true; // Enable gyroscope
    }

    public void StartDataCollection()
    {
        string filePath = Application.persistentDataPath + "/sensor_data.csv";
        try
        {
            fileWriter = new StreamWriter(filePath, false);
            fileWriter.WriteLine("Time,GyroX,GyroY,GyroZ");
            isCollectingData = true;
            Debug.Log("Data collection started");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error starting data collection: " + e.Message);
        }
    }

    public void StopDataCollection()
    {
        if (fileWriter != null)
        {
            try
            {
                fileWriter.Close();
                isCollectingData = false;
                Debug.Log("Data collection stopped");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error stopping data collection: " + e.Message);
            }
        }
    }

    void Update()
    {
        if (isCollectingData)
        {
            string dataLine = Time.time + "," +
                              Input.gyro.rotationRate.x + "," +
                              Input.gyro.rotationRate.y + "," +
                              Input.gyro.rotationRate.z;
            try
            {
                fileWriter.WriteLine(dataLine);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error writing data: " + e.Message);
            }
        }
    }
}
