using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Write SceneMangement namespace if you are used SceneManager to laod scene.

public class UIManager2 : MonoBehaviour
{
	
	void Start()
	{
		
	}
    public void Play()
    {
        //Application.LoadLevel("Level1");//in  this way  not used namespace .
        SceneManager.LoadScene("Level1");//Alos best way to load secen but write namespce SceneManagement.
	
    }
	public void Exit()
	{
		Application.Quit();
		Debug.Log ("Exit");
	}
}
