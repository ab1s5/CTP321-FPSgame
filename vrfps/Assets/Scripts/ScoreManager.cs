using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMesh scoreText;
    public TextMesh stageText;
    void Awake()
    {
        if (!instance)
            instance = this;
    }

    void Start()
    {
        stageText.text = "Stage : " + Variables.stage;
    }

    void Update()
    {
        scoreText.text = "Score : " + Variables.score;
        if (Variables.score >= Variables.stage * 500)
        {
            Variables.AddStage();
            SceneManager.LoadScene("Game");
        }
    }
}