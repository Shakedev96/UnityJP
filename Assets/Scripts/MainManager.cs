using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color teamColor;

    private void Awake()
    {

        //start of new code, neeed a single instance of this
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }
//

    [System.Serializable]
    class SaveData
    {
        public Color TeamColour;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColour = teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data= JsonUtility.FromJson<SaveData>(json);

            teamColor = data.TeamColour;
        }
    }

}
