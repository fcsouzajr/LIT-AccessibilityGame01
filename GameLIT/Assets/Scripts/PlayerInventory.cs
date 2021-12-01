using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public List<string> items = new List<string>();
    public GameObject InventoryUI;

    private void Update() {
        if(Input.GetKeyDown("i")) {
            AddItem("key");
        }
        if (Input.GetKeyDown("o")) {
           RemoveItem("key");
        }
    }

    void AddItem(string itemName) {
        items.Add(itemName);
        InventoryUI.SendMessage("AddItem", itemName);
    }

    void RemoveItem(string itemName) {
        for(int i = 0; i < items.Count; i++) {
            if (items[i] == itemName) {
                items[i].Remove(i);
                break;
            }
        }
        InventoryUI.SendMessage("RemoveItem", itemName);
    }
}
