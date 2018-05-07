using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour {

    private const int MAX_AMM_ITEM = 4;
    private const int SLOTS = 4;
    public List<Item> mItems = null;
    public event EventHandler<InventoryPlayerEventArgs> ItemAdded;
    public event EventHandler<InventoryPlayerEventArgs> ItemRemoved;

    public void Start()
    {
        mItems = new List<Item>();
    }

    public void AddItem(Item item)
    {
        //Debug.Log(mItems.Count);
        if (mItems.Count < SLOTS)
        {
            //Debug.Log("ITEM2");
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                //Debug.Log("ITEM3");
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickUp();
                if (ItemAdded != null)
                {
                    Debug.Log(gameObject.name);
                    ItemAdded(this, new InventoryPlayerEventArgs(item,gameObject.name));
                }
            }
        }
    }

    public List<Item> GetItems()
    {
        return mItems;
    }

    public void RemoveItem(Item item)
    {
        //foreach (List<Item> slot in mItems)
        //{
            
            if (mItems.Remove(item))
            {
                if (ItemRemoved != null)
                {
                    ItemRemoved(this, new InventoryPlayerEventArgs(item, gameObject.name));
                }
                 //break;
            }

       // }
    }

    public void RemoveAllItems(Item item)
    {
        //foreach (List<Item> slot in mItems)
        //{
        mItems.Clear();
            
                if (ItemRemoved != null)
                {
                    ItemRemoved(this, new InventoryPlayerEventArgs(item, gameObject.name));
                }
                 //break;
            

       // }
    }

    //public void RemoveAllItems()
    //{
    //    if (mItems.Count > 0)
    //    {
    //        for (int j = 0; j < mItems.Count; j++)
    //        {
            
    //            RemoveItem(mItems[j]);
    //            //break;
    //        }
    //    }

    //}

    //private InventorySlot FindStackableSlot(InventoryItemBase item)
    //{
    //    foreach (InventorySlot slot in mSlots)
    //    {
    //        if (slot.IsStackable(item))
    //            return slot;
    //    }
    //    return null;
    //}
}
