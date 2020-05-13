using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoSingleton <Boss>
{
    public Material isImmortalMaterial;
    public Material isVulnarableMaterial;

    public bool isImmortal;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        SetImmortal();
    }

    public void SetImmortal() {
        isImmortal = true;
        GetComponent<MeshRenderer>().material = isImmortalMaterial;
    }

    public void SetVulnarable() {
        isImmortal = false;
        GetComponent<MeshRenderer>().material = isVulnarableMaterial;
    }
}
