using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    PlayerScript playerScript;
    public GameObject uiManager;
    UiManager uiManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript=player.GetComponent<PlayerScript>();
        uiManagerScript=uiManager.GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver(playerScript.health);
    }
    void GameOver(int healthValue){
        if(healthValue<=0){
            // Time.timeScale=0;
            uiManagerScript.GameOverUI();
        }
    }
    
}
