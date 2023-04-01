using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject ground;
    public float groundScrollSpeed = 1;
    // The camera that the object should scale with
    public Camera mainCamera;
    // The initial size of the object
    public float acceleration = 0.1f;
    private Vector3 initialSize;
    Renderer groundRenderer;
    private Quaternion targetRotation;
    public int health = 100;
    public int damageRate = 20;
    public float carSpeed;
    public float carSpeedAndroid = 100f;
    public Rigidbody2D rb;
    public float minX;
    public float maxX;
    Vector2 position;
    public UiManager uiManager;
    public bool androidPlatform = false;
    public Button[] touchButtons;
    float horizontalMove;
    public GameObject hitExplosionPrefab;
    public GameObject crashExplosionPrefab;
    public HealthPickup healthPickup;
    public float offset = 22f;

    // Start is called before the first frame update
    void Start()
    {
        groundRenderer = ground.GetComponent<Renderer>();



        // uiManager = GetComponent<UiManager>();
        position = transform.position;
#if UNITY_ANDROID
            androidPlatform = true;
#else
        androidPlatform = false;
#endif
        if (androidPlatform == true)
        {
            Debug.Log("Android support");
        }
        else
        {
            Debug.Log("Window Supports");
        }
        // playerRenderer = GetComponent<Renderer>();
        ScaleWithViewPort(ground);


    }
    // Update is called once per frame
    void Update()
    {


    






        GroundScrolling();
        CrashedExplosions(health);
        TouchMove();
        if (androidPlatform == true)
        {
            //write code for Android Inputs

        }
        else
        {

            position.x += Input.GetAxisRaw("Horizontal") * carSpeed;
            position.x = Mathf.Clamp(position.x, minX, maxX);
            transform.position = position;

            foreach (Button buttons in touchButtons)
            {
                buttons.gameObject.SetActive(false);
            }
        }
        // position.x += Input.GetAxisRaw("Horizontal") * carSpeed;
        // position.x = Mathf.Clamp(position.x, minX, maxX);

        // transform.position = position;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerDamage(damageRate);
            CarHitParticles(collision);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "healthBox")
        {
            health = healthPickup.IncreaseHealth(health, damageRate);
            Destroy(other.gameObject);
        }
    }

    public void TouchMove()
    {
        // only for testing remove when build
        // if (Input.GetMouseButton(0))
        // {
        //     Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        //     transform.position = Vector2.Lerp(transform.position, newPos, 10 * Time.deltaTime);
        // }
        Vector3 touchPosition = GetTouchPosition();
        if (touchPosition != Vector3.zero)
        {
            transform.position=(touchPosition);
        }
    }
    public Vector3 GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 0f);
            // Research letter this line,why give 10 on z
            return Camera.main.ScreenToWorldPoint(touchPosition) + new Vector3(0f, offset, 10f);

        }
        return Vector3.zero;
    }

    public void PlayerDamage(int damageRate)
    {
        health -= damageRate;
    }

    public void GroundScrolling()
    {
        groundScrollSpeed += acceleration * Time.deltaTime;
        float offset = Time.time * groundScrollSpeed;
        groundRenderer.material.mainTextureOffset = new Vector2(0, offset);
    }
    public void ScaleWithViewPort(GameObject gameObject)
    {
        initialSize = gameObject.transform.localScale;
        // Calculate the scale factor based on the camera size
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float scaleX = cameraWidth / initialSize.x;
        float scaleY = cameraHeight / initialSize.y;

        // Apply the scale factor to the object
        gameObject.transform.localScale = new Vector3(scaleX * 9, scaleY * 12, 1f);
    }
    public void CarHitParticles(Collision2D collision)
    {
        GameObject explosionPrefabs = Instantiate(hitExplosionPrefab, collision.contacts[0].point, Quaternion.identity);
        // Destroy particle system after 1 second
        Destroy(explosionPrefabs.gameObject, 0.06f);
    }
    public void CrashedExplosions(int health)
    {
        if (health <= 0)
        {

            GameObject crashedExplosion = Instantiate(crashExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(crashedExplosion.gameObject, 0.4f);
            Destroy(gameObject);

        }
    }

}


