using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Inventory : MonoBehaviour
{
      [SerializeField]
      Inventory_SO _inventory;
      [SerializeField]
      List<UI_InventorySlot> _ui_slots = new List<UI_InventorySlot>();
      public List<UI_InventorySlot> UI_slots { get => _ui_slots; }


      public Action<GameObject> SubscribeToItem;
      public event Action<UI_InventorySlot, PointerEventData> SlotClicked;
      private void Awake( ) {
            DisplayInventory( );
            _inventory.ItemChanged += DisplayInventory;           
      }
      public void DisplayInventory( ) {

            ClearInventory( );
            for ( int i = 0 ; i < _inventory.Items.Count ; i++ ) {
                  var item = (GameObject)Instantiate(Resources.Load("Slot"), transform);
                  var slot = item.GetComponent<UI_InventorySlot>();
                  slot.ID = i;
                  slot.Item = _inventory.Items[ i ].Item;
                  slot.Amount = _inventory.Items[ i ].Amount;
                  _ui_slots.Add( slot );           
                  slot.SlotClicked += SlotClicked;
            }
           
      }
      private void ClearInventory( ) {
            foreach ( var slot in _ui_slots ) {
                  slot.SlotClicked -= SlotClicked;
                  Destroy( slot.gameObject );
            }
            _ui_slots.Clear( );
      }
   


}
