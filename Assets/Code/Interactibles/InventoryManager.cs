using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject canvas;
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
    }
    public bool HasItem(Item item) {
        return items.Contains(item);
    }
    public void ToggleInventory() {
        SetInventory(!canvas.activeSelf);
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
            itemIcon.sprite = item.sprite;
        }
    }
    public void SetInventory(bool val) {
        if (val && SceneController.instance.pauseMenu.activeSelf) {
            return;
        }
        canvas.SetActive(val);
        SceneController.instance.SetPause(val);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            ListItems();
            ToggleInventory();
        }
    }
}
