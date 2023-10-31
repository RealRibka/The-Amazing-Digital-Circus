using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUpObjectAtWorld : MonoBehaviour, IInteract
{
    public bool isCurrentlyPickedUp { get; private set; }
    private Vector3 offset;
    private bool haveRig = false;
    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();

        if(rig != null )
        {
            haveRig = true;
        }
    }
    public void Action()
    {
        isCurrentlyPickedUp = !isCurrentlyPickedUp;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        switch (haveRig)
        {
        
            case true:
                if (isCurrentlyPickedUp)
                {
                    rig.velocity = new Vector3(0,0,0);
                    transform.position = Camera.main.transform.position + Camera.main.transform.forward * offset.magnitude;
                }
                break;
               
            case false:
                if (isCurrentlyPickedUp)
                {
                    transform.position = Camera.main.transform.position + Camera.main.transform.forward * offset.magnitude;
                }
                break;
        }
    }
}
