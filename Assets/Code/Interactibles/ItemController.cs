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
            if (item.type == ItemType.Key) {
                DialogController.instance.DisplayMessage("You find a key, although it looks like it has been here for hundreds of years. You wonder if it will still work.");
            }
            else if (item.type == ItemType.Health) {
                DialogController.instance.DisplayMessage("You find a potion. You assume, perhaps dangerously, that you can use it to recover your health.");
            }
            Destroy(gameObject);
        }
    }
    public static bool UseItem(Item item, GameObject user) {
        if (item.type == ItemType.Health) {
            HealthBar.instance.AddHealth(item.data);
            return true;
        }
        // else if (item.type == ItemType.Key) {
        //     GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        //     if (doors.Length > 0) {
        //         GameObject closest = null;
        //         float closestDist = Mathf.Infinity;
        //         Vector3 position = user.transform.position;
        //         foreach (GameObject door in doors) {
        //             float dist = Vector3.Distance(door.transform.position, position);
        //             if (dist < closestDist) {
        //                 closest = door;
        //                 closestDist = dist;
        //             }
        //         }
        //         print(closestDist);
        //         if (closestDist < 3) {
        //             closest.GetComponent<DoorController>().Unlock();
        //             InventoryManager.instance.SetInventory(false);
        //             DialogController.instance.DisplayMessage("The door opens as the key crumbles into a pile of rust.");
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        return true;
    }
}
