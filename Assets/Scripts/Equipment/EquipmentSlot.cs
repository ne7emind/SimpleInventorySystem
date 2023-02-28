
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
       Equipable_SO _item;
      public Equipable_SO Item {
            get {
                  return _item;
            }
            set {
                  _item = value;
            }
      }

}

