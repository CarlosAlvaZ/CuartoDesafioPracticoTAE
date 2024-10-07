using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47PickUp : Interactable
{

    public GameObject targetWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        Destroy(gameObject);
        targetWeapon.SetActive(true);
    }
}
