using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class S_InventoryDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public S_Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public string name_text = "Grass";
    public string desc_text = "Nice Grass";


    private void Start()
    {
        name_text = item.name_text;
        desc_text = item.desc_text;
    }

    public void InitialiseItem(S_Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();

    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        S_ToolTipManager._instance.showToolTip(name_text, desc_text);
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        S_ToolTipManager._instance.HideToolTip();
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
