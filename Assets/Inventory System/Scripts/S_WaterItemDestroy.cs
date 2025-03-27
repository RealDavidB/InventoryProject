using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_WaterItemDestroy : MonoBehaviour
{

    public GameObject slider;

    
    private void OnTriggerEnter(Collider other)
    {
        slider.GetComponent<Slider>().value += 0.34f;
        Destroy(gameObject);
    }
}
