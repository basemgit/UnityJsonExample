using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public TMP_InputField inputField;
    private void Awake()
    {


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    public class GameData
    {

        public string playerName;

    }

    public void SaveData()
    {
        playerName = inputField.text;
        GameData data = new GameData();
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Saved");
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Loaded");
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            playerName = data.playerName;
            inputField.text = playerName;
        }
    }
}
