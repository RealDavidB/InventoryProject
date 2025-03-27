using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class S_Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType type;
    public r_itemType r_type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    [Header("ToolTip")]
    public string name_text = "Grass";
    public string desc_text = "Nice Grass";

}

public enum ItemType
{
    BuildingBlock,
    Tool
}

public enum r_itemType
{
    Brick,
    Grass,
    Shovel,
    Pickaxe
}

public enum ActionType
{
    Dig,
    Mine
}
