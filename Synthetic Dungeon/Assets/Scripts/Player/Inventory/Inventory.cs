using System.Collections;
using System.Collections.Generic;
using Core;
using Player.Inventory;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int InventorySize = 12;
    private List<Item> _items = new List<Item>();

    public delegate void OnItemUpdate();
    public OnItemUpdate onItemUpdateCallback;
    
    public bool AddItem(Item item)
    {
        if (_items.Count < InventorySize)
        {
            GameManager.LogMessage("Item Has Been Added!", GameManager.MessageType.ALERT);
            _items.Add(item);
            
            onItemUpdateCallback?.Invoke();
            return true;
        }

        return false;
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        onItemUpdateCallback?.Invoke();
    }
}
