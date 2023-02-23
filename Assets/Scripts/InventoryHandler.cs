using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour
{
      [SerializeField]
      UI_Inventory ui_Inventory;

      [SerializeField]
      Inventory_SO inventory_so;

      Inventory inventory;

      [SerializeField]
      UI_Equipment ui_equipment;

      [SerializeField]
      Equipment_SO equipment_so;

      Equipment equipment;

      [SerializeField]
      Transform player;

      [SerializeField]
      Vector2 dropOffset;

      IDataHandler dataHandler;
      private void Awake( ) {
            inventory = new Inventory( );
            dataHandler = new DataManager( inventory );
            equipment = new Equipment( );          
           //   LOAD !   inventory_so.SetItems( dataHandler.Load( ).InventorySlots );
      }
      private void Start( ) {
           ui_Inventory.slotClicked += Ui_Inventory_onItemLeftClicked;
           ui_equipment.ItemClicked += Ui_equipment_ItemClicked;
      }
      private void Ui_equipment_ItemClicked( UI_EquipmentSlot item , PointerEventData eventData ) {
            if ( eventData.button == PointerEventData.InputButton.Left ) {
                  var equipmentType = item.GetItem().Type;
                  Debug.Log( item.GetItem( ) );
                  inventory_so.AddItem( item.GetItem( ));
                  equipment_so.RemoveItem( equipmentType );                                               
            }
      }

      private void Ui_Inventory_onItemLeftClicked( UI_InventorySlot slot , PointerEventData eventData ) {
            if ( eventData.button == PointerEventData.InputButton.Right ) {

                  var itemWorld = (GameObject)Instantiate(Resources.Load(slot.Item.name),
                     (Vector2)player.position + dropOffset,
                     Quaternion.identity);

                   var itemWorldSO = itemWorld.GetComponent<ItemWorld>().Item;                 
                    itemWorldSO.Amount = slot.Amount;
                  inventory_so.RemoveItem( slot.Item );

            }
            else if ( eventData.button == PointerEventData.InputButton.Left ) {
                  if ( !slot.Item.Stackable ) {
                        var item = inventory_so.GetItems()[slot.ID].Item;
                        if ( equipment_so.SetItem( item) )
                              inventory_so.RemoveItem( slot.Item );
                  }
                  else
                        inventory_so.UseItem( slot.Item );

            }

      }
      private void Update( ) {
            if(Input.GetKeyDown(KeyCode.C)) {
                  inventory.InventorySlots = inventory_so.GetItems( );
                  dataHandler.Save( );
            }
      }
      private void OnApplicationQuit( ) {
            inventory_so.GetItems( ).Clear( );
      }


}
