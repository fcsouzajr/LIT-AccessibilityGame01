using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public List<GameObject> knownItems = new List<GameObject>();
    public List<GameObject> items = new List<GameObject>();
    public Vector2 startPosition = new Vector2(350f, 175f);
    public float spaceBetweenItems;

    //private void Update() {
    //    if(Input.GetKeyDown("i")) {
    //        AddItem("key");
    //    }
    //    if (Input.GetKeyDown("o")) {
    //        RemoveItem("key");
    //    }
    //}

    void AddItem(string itemName) {
        int itemID = FindItem(itemName);
        items.Add(knownItems[itemID]);
        ShowItems();
    }

    void RemoveItem(string itemName) {
        for (int i = 0; i < items.Count; i++) {
            if (items[i].name == itemName) {
                items.RemoveAt(i);
                break;
            }
        }
        ShowItems();
    }

    void ShowItems() {
        ClearShowedItems();
        for (int i = 0; i < items.Count; i++) {
            Vector3 auxPosition = new Vector3(startPosition.x, startPosition.y - spaceBetweenItems * i);
            GameObject item = Instantiate(items[i], Vector3.zero, Quaternion.identity, gameObject.transform);
            item.transform.localPosition = auxPosition;
        }
    }

    int FindItem(string itemName) {
        for (int i = 0; i < knownItems.Count; i++) {
            if (knownItems[i].name == itemName) {
                return i;
            }
        }
        return -1;
    }

    void ClearShowedItems() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}
