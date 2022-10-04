using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Interactible
{
    public Item item;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            InventoryManager.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
    public static void UseItem(Item item, GameObject user) {
        if (item.type == ItemType.Health) {
            HealthBar.instance.AddHealth(item.data);
        }
    }
}
