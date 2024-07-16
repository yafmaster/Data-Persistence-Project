using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public TMP_InputField inputName;


    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.LoadBestScore();
        Debug.Log($"Best score info = {GameManager.Instance.GetBestScoreInfo()}");

        BestScoreText.text = GameManager.Instance.GetBestScoreInfo();
        if (GameManager.Instance.PlayerName.Length > 0) {
            inputName.text = GameManager.Instance.PlayerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName()
    {
        if (inputName.text.Length > 0)
        {
            GameManager.Instance.SetPlayerName(inputName.text);
            Debug.Log($"Input= {inputName.text}, Player name = {GameManager.Instance.PlayerName}");
        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        GameManager.Instance.SaveBestScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
