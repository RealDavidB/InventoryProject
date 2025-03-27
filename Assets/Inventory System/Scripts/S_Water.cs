using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Water : MonoBehaviour
{
    public GameObject water1;
    public GameObject water1_inv;
    public GameObject water2;
    public GameObject water2_inv;
    public GameObject water3;
    public GameObject water3_inv;

    private void Update()
    {
        if(water1 == null)
        {
            water1_inv.SetActive(true);
        }
        if (water2 == null)
        {
            water2_inv.SetActive(true);
        }
        if (water3 == null)
        {
            water3_inv.SetActive(true);
        }
    }
}
