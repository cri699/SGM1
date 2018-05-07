using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryPlayerEventArgs : EventArgs
{
    public Item Item;
    public string NameInventory; 
    public InventoryPlayerEventArgs(Item item, string nameInventory)
    {
        Item = item;
        NameInventory = nameInventory;
    }

}