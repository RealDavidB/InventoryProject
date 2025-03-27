using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlaceBlocks : MonoBehaviour
{
    bool canPickUp = false;
    bool empty = true;
    public bool brickScript = true;
    public GameObject placedBlock;
    public GameObject demoObject;
    S_DemoScript demoScript;

    private void OnTriggerEnter(Collider other)
    {
        canPickUp = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canPickUp = false;
    }

    private void Start()
    {
        demoScript = demoObject.GetComponent<S_DemoScript>();
    }

    private void Update()
    {
        if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && empty)
            {
                if(brickScript)
                {
                    demoScript.UseSelectedItem();
                }
                else
                {
                    demoScript.UseSelectedGrassItem();
                }
                
                if(demoScript.inventoryManager.PickedUp)
                {
                    placedBlock.SetActive(true);
                    empty = false;
                }                              
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && !empty)
            {
                if(brickScript)
                {
                    demoScript.PickupItem(2);
                }
                else
                {
                    demoScript.PickupItem(0);
                }
                placedBlock.SetActive(false);
                empty = true;
            }
        }
    }
}
