using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;

public class S_ToolTipManager : MonoBehaviour
{
    public static S_ToolTipManager _instance;

    public TextMeshProUGUI name_text;
    public TextMeshProUGUI desc_text;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        gameObject.SetActive(false);  
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void showToolTip(string name, string desc)
    {
        gameObject.SetActive(true);
        name_text.text = name;
        desc_text.text = desc;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        name_text.text = string.Empty;
        desc_text.text = string.Empty;
    }
}
