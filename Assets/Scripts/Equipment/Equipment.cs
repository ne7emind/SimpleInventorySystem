using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment
{
      [SerializeField]
      EquipmentSlot[ ] _equipmentSlots = new EquipmentSlot[7];
      public EquipmentSlot[ ] EquipmentSlots {
            get {
                  return _equipmentSlots;
            }
            set {
                  _equipmentSlots = value;
            }
      }

}
