using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gameManager;
    [HideInInspector]
    public GameManager gameManagerScript;
    public GameObject floor;
    public GameObject restartUI;
    public GameObject winUI;
    public GameObject platform;
    public Material currentFloorMaterial;
    public Material pastFloorMaterial;
    public float speed = 10.0f;

    float horizontalMovement;
    float verticalMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = new GameManager();
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        if (horizontalMovement > 0)
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalMovement);
        else
            Debug.Log("Cannot go back!");
        transform.Translate(Vector3.up * Time.deltaTime * verticalMovement * speed);
        
        TimeSwitch();
    }

    void TimeSwitch()
    {
        Debug.Log("The player value in bool is " + gameManagerScript.isCurrentTimeLine);

        if (gameManagerScript.isCurrentTimeLine)
        {
            Debug.Log("Inside true. ");
            floor.GetComponent<SpriteRenderer>().material = currentFloorMaterial;
            Camera.main.backgroundColor = Color.blue;
        }
        else
        {
            floor.GetComponent<SpriteRenderer>().material = pastFloorMaterial;
            Camera.main.backgroundColor = Color.grey;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "DeathZone")
        {
            //create a canvas for death screen

            //Destroy the player
            gameObject.SetActive(false);
            restartUI.SetActive(true);

            //Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Goal")
        {
            gameObject.SetActive(false);
            winUI.SetActive(true);
            //add end game condition.
        }

        else if (collision.collider.tag == "BounceBack")
        {
            //bounce back functionality
            gameObject.transform.position = new Vector3(60.0f, -1.2f, 0);
        }

        else if (collision.collider.tag == "PlatformButton")
        {
            //platform movement functionality
            platform.transform.position = new Vector3(75.16f, platform.transform.position.y - 6.0f, 0);

            //Debug.Log("Button collision. ");
        }
    }
}
