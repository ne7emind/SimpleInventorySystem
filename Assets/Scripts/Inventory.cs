using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
      [SerializeField]
      List<InventorySlot> slots = new List<InventorySlot>();

      public List<InventorySlot> InventorySlots {
            get {
                  return slots;
            }
            set {
                  slots = value;
            }
      }
}
