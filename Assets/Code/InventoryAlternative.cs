using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAlternative : MonoBehaviour
{

    public GameObject inventory;
    private InventoryManager inventoryManager;

    private void Start() {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        string items = "[";
        foreach (Item i in inventoryManager.items) {
            items += " " + i.itemName;
        }
        items += "]";
        print(items);

        if(Input.GetKeyDown(KeyCode.Q)) {
            print("trying alternative use of inventory potion");
            Item item = null;
            // Look for Small Potion
            foreach (Item i in inventoryManager.items) {
                if (i.itemName == "Small Potion") {
                    print("Found small potion... using!");
                    item = i;
                    break;
                }
            }

            if (item == null) {
                // Look for Large Potion
                foreach (Item i in inventoryManager.items) {
                    if (i.itemName == "Large Potion") {
                        print("found large potion... using!");
                        item = i;
                        break;
                    }
            }
            }

            



            if (item != null) {
                inventoryManager.UseItem();
                print("used item!");
            }
            else {
                print("item not found...");
                return;
            }
        }
    }
}
