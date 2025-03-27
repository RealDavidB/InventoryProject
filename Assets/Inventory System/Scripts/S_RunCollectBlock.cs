using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RunCollectBlock : MonoBehaviour
{

    public GameObject demoObject;
    public item item;
    S_DemoScript demoScript;

    private void Start()
    {
        demoScript = demoObject.GetComponent<S_DemoScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        demoScript.PickupItem((int)item);
        Destroy(gameObject);
    }

}

public enum item
{
    Grass,
    Shovel,
    Brick,
    Pickaxe
}
