using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    PlayerScript playerScript;
    public GameObject player;
    public ScoreScript scorScript;
    //public Text scoreText;
    //int score;
    bool gameOver;
    //public float scoreStartTime;
    //public float scoreRepeatingTime;
    public Button[] buttons;
    public Image[] healthBarImages;

    private void Start()
    {


        playerScript = player.GetComponent<PlayerScript>();
        if (playerScript == null)
        {
            Debug.LogError("OtherScript component not found on the same GameObject as MyScript.");
        }

        //  score = 0;
        gameOver = false;
        //InvokeRepeating("ScoreManger",scoreStartTime ,scoreRepeatingTime );
    }
    private void Update()
    {
        // scoreText.text = "Score:" + score;
        UpdateHealthUi(playerScript.health);


    }
    public void ScoreManger()
    {
        if (gameOver == false)
        {

            // scorScript.ScoreManager(1);

        }
    }
    public void GameOverUI()
    {
        gameOver = true;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void Pouse()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void Replay()
    {
        //Application.LoadLevel("Level1");
        SceneManager.LoadScene("Level1");
    }
    public void MainManue()
    {
        //Application.LoadLevel("MainManu");
        SceneManager.LoadScene("MainManu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void UpdateHealthUi(int healthValue)
    {
        for (int i = 0; i < healthBarImages.Length; i++)
        {
            switch (i)
            {
                case 0:
                    if (healthValue <= 70)
                    {

                        healthBarImages[i].gameObject.SetActive(false);
                    }else{
                        healthBarImages[i].gameObject.SetActive(true);
                    }
                    break;
                case 1:
                    if (healthValue <= 40)
                    {

                        healthBarImages[i].gameObject.SetActive(false);
                        healthBarImages[i + 1].color = Color.red;
                    }
                    else{
                        healthBarImages[i].gameObject.SetActive(true);
                        healthBarImages[i + 1].color = Color.green;
                    }
                    break;
                case 2:
                    if (healthValue <= 0)
                    {

                        healthBarImages[i].gameObject.SetActive(false);

                    }
                    break;
                default:
                    break;
            }
        }


    }

}
