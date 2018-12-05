﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public UnityEngine.UI.Text scoreText;
    public int score;
    public int stage;
    void Awake()
    {
        score = 0;
        stage = 1;
        if (!instance)
            instance = this;
    }

    public void AddScore(int num)
    {
        score += num*stage;
        scoreText.text = "Score : " + score;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}