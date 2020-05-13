using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController>
{
    [SerializeField] float moveSpeed = 50.0f;
    [SerializeField] float turnSpeed = 100.0f;

    Vector3 motion;

    public float gravityModifier = 1.0f;

    Rigidbody playerRb;

    Transform camBody;
    float pitchRotation;

    public bool isDead;
    public int health = 100000;

    public int keyCount = 0;
    bool hasKey;
        
    float xBound = 25f;
    float zBound = 25f;

    public int cageCount = 1;

    private Vector3 playerDefaultPos;


    // Start is called before the first frame update
    void Start()
    {
        playerDefaultPos = transform.position;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        GameManager.Instance.UpdateKeyCountText();
        GameManager.Instance.UpdateHealthText();

        CameraSetup();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

        //throw Bomb
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ThrowProjectile>().Throw();
        }
    }

    void CameraSetup()
    {
        Camera cam = GetComponentInChildren<Camera>();
        if (cam == null)
            Debug.LogError("Player missing cam");
        else
            camBody = cam.transform;

        pitchRotation = camBody.rotation.eulerAngles.x;

      //  Cursor.lockState = CursorLockMode.Locked;
    }

    void MovePlayer()
    {
        if (!isDead && GameManager.Instance.isGameActive)
        {
            Move();
        }
    }

    void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 offset = new Vector3(0f, 0f, verticalInput * moveSpeed * Time.deltaTime);
        Vector3 newPos = playerRb.position + transform.TransformDirection(offset);
        playerRb.MovePosition(newPos);

        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        PlayerAnimation.Instance.Movement(verticalInput);
    }
    
    void ConstrainPlayerPosition()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= collision.gameObject.GetComponent<Enemy>().meleeDamage;
            GameManager.Instance.UpdateHealthText();

            if (health < 1)
            {
                PlayerAnimation.Instance.Death();
                isDead = true;
            }
        }

        if (collision.gameObject.CompareTag("Cage") && keyCount > 0)
        {
            keyCount--;
            GameManager.Instance.UpdateKeyCountText();
            collision.gameObject.GetComponent<Cage>().PickUp();

            cageCount--;
            if (cageCount < 1)
            {
                Boss.Instance.SetVulnarable();
            }
        }

        if (collision.gameObject.CompareTag("Boss") && Boss.Instance.isImmortal == false)
        {
            Boss.Instance.isDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cure")
        {
            other.gameObject.GetComponent<Consumable>().PickUp();
            health += 1;
            GameManager.Instance.UpdateHealthText();
        }

        if (other.tag == "Key")
        {
            other.gameObject.GetComponent<Consumable>().PickUp();
            keyCount++;
            GameManager.Instance.UpdateKeyCountText();
            hasKey = true;
        }
    }

    // Move player back to start position
    public void ResetPlayer()
    {
        hasKey = false;
        cageCount = SpawnManager.Instance.waveNumber;
        transform.position = playerDefaultPos;
        playerRb.velocity = Vector3.zero;
    }
}
