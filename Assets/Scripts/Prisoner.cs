using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour
{
    [SerializeField] AudioClip releaseSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float flyAwaySpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Release()
    {
        audioSource.PlayOneShot(releaseSound);
        FlyAway();
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
