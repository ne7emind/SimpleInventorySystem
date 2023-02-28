using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Equipment : MonoBehaviour
{
      [SerializeField]
      UI_EquipmentSlot[] _uI_EquipmentSlots;
      [SerializeField]
      Equipment_SO _equipment;
      public Equipment_SO Equipment { set => _equipment = value; }

      public event Action<UI_EquipmentSlot, PointerEventData> ItemClicked;
      private void OnValidate( ) {
            _uI_EquipmentSlots = new UI_EquipmentSlot[ 7 ];
            _uI_EquipmentSlots = GetComponentsInChildren<UI_EquipmentSlot>( );
      }
      private void Start( ) {
            foreach ( var slot in _uI_EquipmentSlots ) {
                  slot.ItemClicked += ItemClicked;
            }
            if ( _equipment != null ) {
                  DisplayEquipment( );
                  _equipment.EquipmentChanged += DisplayEquipment;
            }
            else
                  Debug.LogError( "No equipment selected" );
      }

      public void DisplayEquipment( ) {
            for ( int i = 0 ; i < _uI_EquipmentSlots.Length ; i++ ) {
                  _uI_EquipmentSlots[ i ].Item = _equipment.EquipmentSlots[ i ].Item;
            }

      }
}

