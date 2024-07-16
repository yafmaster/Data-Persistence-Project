using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string DATA_FILE_PATH;

    private string BestPlayer;
    private int BestScore;
    public string PlayerName;


    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        DATA_FILE_PATH = Application.persistentDataPath + "/score.json";

        LoadBestScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string playerName)
    {
        PlayerName = playerName;
    }

    public string GetBestScoreInfo()
    {
        return $"Best Score: {BestPlayer} : {BestScore}";
    }

    public void UpdateBestScoreInfo(string name, int score)
    {
        if (score > BestScore)
        {
            BestPlayer = name;
            BestScore = score;
            Debug.Log($"Best score updated: {name}, {score}");
        }
    }

    [System.Serializable]
    class BestScoreData
    {
        public int score;
        public string name;
    }

    public void SaveBestScore()
    {
        BestScoreData data = new BestScoreData();
        data.score = BestScore;
        data.name = BestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(DATA_FILE_PATH, json);

        Debug.Log($"Save best score: path = {Application.persistentDataPath}");
        Debug.Log($"Save best score: data = {json}");
    }

    public void LoadBestScore()
    {
        //string path = Application.persistentDataPath + "/score.json";
        Debug.Log($"Load best score: path = {DATA_FILE_PATH}");

        if (File.Exists(DATA_FILE_PATH))
        {
            string json = File.ReadAllText(DATA_FILE_PATH);
            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);

            BestPlayer = data.name;
            BestScore = data.score;

            Debug.Log($"Load best score: data = {BestPlayer}, {BestScore}");
        } 
        else
        {
            BestPlayer = "None";
            BestScore = 0;
        }
    }
}
