using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Inventory : MonoBehaviour
{
      [SerializeField]
      Inventory_SO inventory;
      [SerializeField]
      List<UI_InventorySlot> ui_slots = new List<UI_InventorySlot>();
      public List<UI_InventorySlot> UI_slots { get => ui_slots; }


      public Action<GameObject> subscribeToItem;
      public event Action<UI_InventorySlot, PointerEventData> slotClicked;
      private void Awake( ) {
            DisplayInventory( );
            inventory.itemChanged += DisplayInventory;           
      }
      public void DisplayInventory( ) {

            ClearInventory( );
            for ( int i = 0 ; i < inventory.GetItems( ).Count ; i++ ) {
                  var item = (GameObject)Instantiate(Resources.Load("Slot"), transform);
                  var slot = item.GetComponent<UI_InventorySlot>();
                  slot.ID = i;
                  slot.Item = inventory.GetItems( )[ i ].Item;
                  slot.Amount = inventory.GetItems( )[ i ].Amount;
                  ui_slots.Add( slot );           
                  slot.slotClicked += slotClicked;
            }
           
      }
      private void ClearInventory( ) {
            foreach ( var slot in ui_slots ) {
                  slot.slotClicked -= slotClicked;
                  Destroy( slot.gameObject );
            }
            ui_slots.Clear( );
      }
   


}
