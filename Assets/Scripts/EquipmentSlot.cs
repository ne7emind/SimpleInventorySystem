using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentSlot
{
      public enum ItemType
      {
            armour,
            helmet,
            legs,
            weapon,
            shield,
            ring,
            necklace,
            potion
      }
      public ItemType Type;
      [SerializeField]
       Equipable_SO item;
      public Equipable_SO Item {
            get {
                  return item;
            }
            set {
                  item = value;
            }
      }

}

