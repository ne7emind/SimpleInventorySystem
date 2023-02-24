using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

abstract public class Equipment_SO : ScriptableObject
{
      [SerializeField]
      EquipmentSlot[ ] equipmentSlots = new EquipmentSlot[7];
      public EquipmentSlot[ ] EquipmentSlots { get { return equipmentSlots; } set { equipmentSlots = value; } }
      public event Action<Item_SO> ItemEquiped;
      public event Action<Item_SO> ItemUnequiped;
      public event Action equipmentChanged;


      public bool SetItem( Item_SO item ) {
            for ( int i = 0 ; i < equipmentSlots.Length ; i++ ) {
                  if ( ( int ) equipmentSlots[ i ].Type == ( int ) item.Type ) {
                        if ( equipmentSlots[ i ].Item == null ) {
                              equipmentSlots[ i ].Item = ( Equipable_SO ) item;
                              ItemEquiped?.Invoke( item );
                              equipmentChanged?.Invoke( );
                              return true;
                        }

                  }
            }
            return false;
      }
      public void RemoveItem( Item_SO.ItemType itemType ) {
            for ( int i = 0 ; i < equipmentSlots.Length ; i++ ) {
                  if ( ( int ) equipmentSlots[ i ].Type == ( int ) itemType ) {
                        Debug.Log( i );
                        ItemUnequiped?.Invoke( equipmentSlots[ i ].Item );
                        equipmentSlots[ i ].Item = null;
                        equipmentChanged?.Invoke( );
                        return;
                  }
            }
      }
}
