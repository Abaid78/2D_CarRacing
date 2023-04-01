using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float speed = 0.1f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*speed*Time.deltaTime);
        
    }
    public int IncreaseHealth(int health, int increaseAmount)
    {
        if (health < 100)
        {

            health += increaseAmount;
        }
        return health;
    }
}
