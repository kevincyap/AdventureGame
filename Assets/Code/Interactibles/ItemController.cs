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
}
