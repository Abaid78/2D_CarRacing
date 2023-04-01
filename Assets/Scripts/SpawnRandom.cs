using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public GameObject healthBoxPrefab;
    int carNo; //means how many car we spone.
    public float minRange;
    public float maxRange;
    public float delayTime = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

        ViewPortBoundaries();
        StartCoroutine(SpawnEveryInterval());
        timer = delayTime;
        // delayTime = StaticsVariables.staticDelayTime;

        //InvokeRepeating("SponeCar", 1, 2);//Also use this mathods for delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carPoss = new Vector3(Random.Range(minRange, maxRange), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 5);//we have six car so we write in Random.Range methods 0,5.
            Instantiate(carPrefabs[carNo], carPoss, transform.rotation);
            timer = delayTime;
        }


    }
    public void ViewPortBoundaries()
    {
        Vector3 minPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 maxPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.8f, 0, Camera.main.nearClipPlane));

        float minX = minPosition.x;
        float maxX = maxPosition.x;
        minRange = minX;
        maxRange = maxX;
    }
    void SpawnHealthBox()
    {
        Vector2 position = new Vector2(Random.Range(minRange, maxRange), transform.position.y);
        Instantiate(healthBoxPrefab, position, Quaternion.identity);
    }
    private IEnumerator SpawnEveryInterval()
    {
        while (true)
        {

            yield return new WaitForSeconds(1f);
            SpawnHealthBox();
        }

    }

}
