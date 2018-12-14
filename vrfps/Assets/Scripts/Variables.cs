using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Variables{

    public static int stage = 0;
    public static int score = 0;

	// Use this for initialization
	public static void AddScore (int num) {
        score += num;
        Debug.Log(score);
    }

    public static void AddStage()
    {
        stage += 1;
    }
}
