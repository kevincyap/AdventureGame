using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string ID;
    public string itemName;
    public string itemDesc;
    public ItemType type;
    public Sprite sprite;
    public int data;
    //public AudioClip audioClip;
}