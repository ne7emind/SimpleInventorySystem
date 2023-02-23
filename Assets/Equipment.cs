using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment
{
      [SerializeField]
      EquipmentSlot[ ] equipmentSlots = new EquipmentSlot[7];
      public EquipmentSlot[ ] EquipmentSlots {
            get {
                  return equipmentSlots;
            }
            set {
                  equipmentSlots = value;
            }
      }

}
