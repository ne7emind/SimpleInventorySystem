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

      public event Action<UI_EquipmentSlot, PointerEventData> ItemClicked;
      private void OnValidate( ) {
            uI_EquipmentSlots = new UI_EquipmentSlot[ 7 ];
            uI_EquipmentSlots = GetComponentsInChildren<UI_EquipmentSlot>( );
      }
      private void Start( ) {
            foreach ( var slot in uI_EquipmentSlots ) {
                  slot.ItemClicked += ItemClicked;
            }
            DisplayEquipment( );
            equipment.equipmentChanged += DisplayEquipment;
      }

      public void DisplayEquipment( ) {
            for ( int i = 0 ; i < uI_EquipmentSlots.Length ; i++ ) {                            
                  uI_EquipmentSlots[ i ].SetItem( equipment.EquipmentSlots[ i ].Item );
            }

      }
}

