using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Chest : MonoBehaviour
{
    public GameObject chestUI;
    public GameObject invUI;
    public GameObject waterSlider;
    public GameObject waterText;
    public GameObject invText;
    public GameObject chestText;
    bool inCollision = false;
    bool inChest = false;

    private void Start()
    {
        inCollision = false;
        inChest = false;
    }
    void Update()
    {
        if (inCollision) { Debug.Log("FFFFF"); }
        if(inCollision && Input.GetKey(KeyCode.Mouse1))
        {
            chestUI.SetActive(true);
            invUI.SetActive(true);
            waterSlider.SetActive(false);
            invText.SetActive(true);
            chestText.SetActive(true);
            inChest = true;
        }
        if(inChest)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player Character")
        {
            inCollision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inCollision = false;
        chestUI.SetActive(false);
        invUI.SetActive(false);
        waterSlider.SetActive(true);
        invText.SetActive(false);
        inChest = false;
        chestText.SetActive(false);
    }
}
