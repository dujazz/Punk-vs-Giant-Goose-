using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : Item
{
    [SerializeField] GameObject prisoner;
    bool isPrisonerReleased;

    private void Update()
    {
        if (this.IsTaken && !isPrisonerReleased)
        {
            prisoner.transform.parent = null;
            prisoner.GetComponent<Prisoner>().Release();
            GetComponent<Rigidbody>().detectCollisions = false;
            isPrisonerReleased = true;
        }
    }

}
