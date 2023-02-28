using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
      [SerializeField]
      List<InventorySlot> _slots = new List<InventorySlot>();

      public List<InventorySlot> InventorySlots {
            get {
                  return _slots;
            }
            set {
                  _slots = value;
            }
      }
}
