using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Inventory : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject inventoryCam;
    public GameObject invSlots;
    public GameObject invText;
    public GameObject waterText;
    public GameObject slider;
    public GameObject chestUI;
    public GameObject chestText;
    bool inInventory = false;

    void Update()
    {
        if(inInventory)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!inInventory && !chestUI.activeSelf)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(Input.GetKeyDown(KeyCode.E) && !inInventory)
        {
            playerCam.SetActive(false);
            inventoryCam.SetActive(true);
            invSlots.SetActive(true);
            invText.SetActive(true);
            waterText.SetActive(true);
            slider.SetActive(false);
            chestUI.SetActive(false);
            chestText.SetActive(false);
            Time.timeScale = 0.0f;
            inInventory = true;
        }
        else if(Input.GetKeyDown(KeyCode.E) && inInventory)
        {
            playerCam.SetActive(true);
            inventoryCam.SetActive(false);
            invSlots.SetActive(false);
            invText.SetActive(false);
            waterText.SetActive(false);
            slider.SetActive(true);
            Time.timeScale = 1.0f;
            inInventory = false;
        }
    }
}
