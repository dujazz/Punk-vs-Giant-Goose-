using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour
{
    [SerializeField] AudioClip releaseSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float flyAwaySpeed = 5f;

    GameObject player;

    bool isFree;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFree)
        {
            transform.LookAt(player.transform);
        }
    }

    public void Release()
    {
        audioSource.PlayOneShot(releaseSound);
        FlyAway();
        isFree = true;
    }

    private void FlyAway()
    {
        transform.Translate(Vector3.up);
        StartCoroutine(FlyAwayRoutine());
    }

    IEnumerator FlyAwayRoutine()
    {
        while (transform.position.y < 50)
        {
            transform.Translate(Vector3.up * Time.deltaTime * flyAwaySpeed);
            yield return null;
        }
        Destroy(gameObject);
    }

}
