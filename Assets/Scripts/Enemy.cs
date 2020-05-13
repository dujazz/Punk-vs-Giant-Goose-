using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody enemmyRb;
    private GameObject player;
    private Vector3 directionToPlayer;
    private float yDestory = -5.0f;
    public int meleeDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemmyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        DestroyIfOutOfBounds();

    }

    protected void ChasePlayer()
    {
        directionToPlayer = player.transform.position - transform.position;
        //transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * speed);
        enemmyRb.AddForce(directionToPlayer.normalized * speed);

        Debug.DrawRay(transform.position, directionToPlayer, Color.green); //looks cool
    }

    //Not works, so i use ChasePlayer()
    protected void ChasePlayerLookAt()
    {
        transform.LookAt(player.transform.position);
        enemmyRb.AddForce(Vector3.forward * speed);
    }


    protected void DestroyIfOutOfBounds()
    {
        if (transform.position.y < yDestory)
        {
            Destroy(gameObject);
        }
    }
}
