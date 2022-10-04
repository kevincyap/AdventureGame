using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject ItemDesc;
    public static InventoryManager instance;
    public GameObject ItemPrefab;
    public Transform ItemPanel;
    public List<Item> items = new List<Item>();
    void Start()
    {
        instance = this;
    }
    public void AddItem(Item item) {
        items.Add(item);
    }
    public void RemoveItem(Item item) {
        items.Remove(item);
        ListItems();
    }
    public bool HasItem(Item item) {
        return items.Contains(item);
    }
    public void UseItem(Item item) {
        RemoveItem(item);
        HealthBar.instance.addHealth(item.healthRestore);
        ItemDesc.SetActive(false);
    }
    public void DiscardItem(Item item) {
        RemoveItem(item);
        ItemDesc.SetActive(false);
    }

    public void CloseItemDesc() {
        ItemDesc.SetActive(false);
    }

    public void ShowItemDesc (Item item) {
        var panel = ItemDesc.transform.Find("Panel").GetComponent<Image>();
        ItemDesc.SetActive(true);
        var itemName = panel.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemName.SetText(item.itemName);
        var itemDesc = panel.transform.Find("ItemDesc").GetComponent<TextMeshProUGUI>();
        itemDesc.SetText(item.itemDesc);
        var itemIcon = panel.transform.Find("Icon").GetComponent<Image>();
        itemIcon.sprite = item.sprite;
        Button useButton = panel.transform.Find("Use").GetComponent<Button>();
        useButton.onClick.AddListener(delegate { UseItem(item); });
        Button discardButton = panel.transform.Find("Discard").GetComponent<Button>();
        discardButton.onClick.AddListener(delegate { DiscardItem(item); });
    }

    public void ToggleInventory() {
        SetInventory(!Inventory.activeSelf);
    }
    public void ListItems() {
        foreach (Transform child in ItemPanel) {
            Destroy(child.gameObject);
        }
        foreach (Item item in items) {
            GameObject obj = Instantiate(ItemPrefab, ItemPanel);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            itemName.SetText(item.itemName);
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(delegate { ShowItemDesc(item); });
            itemIcon.sprite = item.sprite;
        }
    }
    public void SetInventory(bool val) {
        if (val && SceneController.instance.pauseMenu.activeSelf) {
            return;
        }
        Inventory.SetActive(val);
        ItemDesc.SetActive(false);
        SceneController.instance.SetPause(val);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E) && !ItemDesc.activeSelf) {
            ListItems();
            ToggleInventory();
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            if (ItemDesc.activeSelf) {
                ItemDesc.SetActive(false);
            } else if (Inventory.activeSelf){
                SetInventory(false);
            }
        }
    }
}
