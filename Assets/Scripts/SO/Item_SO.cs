using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item_SO : ScriptableObject {
      public enum ItemType {
            armour,
            helmet,
            legs,
            weapon,
            shield,
            ring,
            necklace,
            potion
                
      }
      public int Amount;
      public ItemType Type;
      public bool Stackable;
      public Sprite sprite;
}
