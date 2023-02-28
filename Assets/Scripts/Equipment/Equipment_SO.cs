using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

abstract public class Equipment_SO : ScriptableObject
{
      [SerializeField]
      EquipmentSlot[ ] _equipmentSlots = new EquipmentSlot[7];
      public EquipmentSlot[ ] EquipmentSlots { get { return _equipmentSlots; } set { _equipmentSlots = value; } }
      public event Action<Item_SO> ItemEquiped;
      public event Action<Item_SO> ItemUnequiped;
      public event Action EquipmentChanged;


      public bool SetItem( Item_SO item ) {
            for ( int i = 0 ; i < _equipmentSlots.Length ; i++ ) {
                  if ( ( int ) _equipmentSlots[ i ].Type == ( int ) item.Type ) {
                        if ( _equipmentSlots[ i ].Item == null ) {
                              _equipmentSlots[ i ].Item = ( Equipable_SO ) item;
                              ItemEquiped?.Invoke( item );
                              EquipmentChanged?.Invoke( );
                              return true;
                        }

                  }
            }
            return false;
      }
      public void RemoveItem( Item_SO.ItemType itemType ) {
            for ( int i = 0 ; i < _equipmentSlots.Length ; i++ ) {
                  if ( ( int ) _equipmentSlots[ i ].Type == ( int ) itemType ) {
                        Debug.Log( i );
                        ItemUnequiped?.Invoke( _equipmentSlots[ i ].Item );
                        _equipmentSlots[ i ].Item = null;
                        EquipmentChanged?.Invoke( );
                        return;
                  }
            }
      }
}
