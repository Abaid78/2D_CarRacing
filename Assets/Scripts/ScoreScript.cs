using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	int myScore = 0;

	public Text scoreText;
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text =myScore.ToString () ;
		
	}
	public void ScoreManager(int score)
    {
		myScore = myScore + score;
    }
}