﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    //public GameObject Items;
    public List<Item> Inventory = new List<Item>();
    public Item ItemScr;
    bool inventoryEnabled;
    public GameObject InvGraph;
    int allSlots;
    int enabledSlots;
    GameObject[] Slot;
    public GameObject slotHolder;
    //Item functions on pick up

    private void Start()
    {
        allSlots = 40;
        Slot = new GameObject[allSlots];
        for(int i=0;i<allSlots;i++)
        {
            Slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (Slot[i].GetComponent<Slot>().item == null)
                Slot[i].GetComponent<Slot>().empty = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            pickUp(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            addItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }
    public void pickUp(GameObject I)
    {
        ItemScr = I.GetComponent<Item>();
        Inventory.Add(ItemScr);
        I.SetActive(false);
        Debug.Log("Item picked up");
    }
    void addItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i=0;i<allSlots;i++)
        {
            if(Slot[i].GetComponent<Slot>().empty)
            {
                //add item to slot
                itemObject.GetComponent<Item>().pickedUp = true;
                Slot[i].GetComponent<Slot>().item = itemObject;
                Slot[i].GetComponent<Slot>().icon = itemIcon;
                Slot[i].GetComponent<Slot>().type = itemType;
                Slot[i].GetComponent<Slot>().ID = itemID;
                Slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = Slot[i].transform;
                itemObject.SetActive(false);

                Slot[i].GetComponent<Slot>().UpdateSlot();
                Slot[i].GetComponent<Slot>().empty = false;
            }
            return;
        }
    }
    public void drop(Item I)
    {
        Inventory.Remove(I);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Inventory.RemoveAt(0);
            Debug.Log("item 1 used");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Inventory.RemoveAt(1);
            Debug.Log("item 2 used");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Inventory.RemoveAt(3);
            Debug.Log("item 3 used");
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled == true)
        {
            InvGraph.SetActive(true);
        }
        else
        {
            InvGraph.SetActive(false);
        }
    }
}
