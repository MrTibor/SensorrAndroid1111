using UnityEngine;

public class PathTester : MonoBehaviour
{
    void Start()
    {
        string persistentDataPath = Application.persistentDataPath;
        Debug.Log("Persistent Data Path: " + persistentDataPath);
    }
}
