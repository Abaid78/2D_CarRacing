using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
	public UiManager uiManager;
	
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject .tag =="Enemy")
        {
            Destroy(other.gameObject);
			uiManager.ScoreManger();
			
        }		
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
	
	
		
	
}
