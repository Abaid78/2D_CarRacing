using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 50f;
    public float acceleration=0.1f;
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        speed+=acceleration;
        transform.Translate(Vector2.up* Time.deltaTime*speed);
        float distanceFromPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceFromPlayer > 15)
        {
            Destroy(gameObject);
        }


        transform.Translate(Vector2.up * Time.deltaTime);
    }
}
