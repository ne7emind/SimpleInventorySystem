using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Equipment : MonoBehaviour
{
      [SerializeField]
      UI_EquipmentSlot[] uI_EquipmentSlots;
      [SerializeField]
      Equipment_SO equipment;
      public Equipment_SO Equipment { set => equipment = value; }

      public event Action<UI_EquipmentSlot, PointerEventData> ItemClicked;
      private void OnValidate( ) {
            uI_EquipmentSlots = new UI_EquipmentSlot[ 7 ];
            uI_EquipmentSlots = GetComponentsInChildren<UI_EquipmentSlot>( );
      }
      private void Start( ) {
            foreach ( var slot in uI_EquipmentSlots ) {
                  slot.ItemClicked += ItemClicked;
            }
            if ( equipment != null ) {
                  DisplayEquipment( );
                  equipment.equipmentChanged += DisplayEquipment;
            }
            else
                  Debug.LogError( "No equipment selected" );
      }

      public void DisplayEquipment( ) {
            for ( int i = 0 ; i < uI_EquipmentSlots.Length ; i++ ) {
                  uI_EquipmentSlots[ i ].Item = equipment.EquipmentSlots[ i ].Item;
            }

      }
}

