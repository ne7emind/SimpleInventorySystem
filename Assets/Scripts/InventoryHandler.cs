using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour
{
      [SerializeField]
      GameObject inventoryObject;

      [Header("Inventory")]
      [SerializeField]
      UI_Inventory ui_Inventory;
      [Space]
      [SerializeField]
      Inventory_SO inventory_so;

      Inventory inventory;
      [Header("Equipment")]
      [SerializeField]
      UI_Equipment ui_equipment;
      [Space]
      [SerializeField]
      Equipment_SO equipment_so;

      Equipment equipment;
      [Header("Player")]
      [SerializeField]
      Player player;
      [Space]
      [SerializeField]
      Vector2 dropOffset;
      IDataHandler dataHandler;
      private void Awake( ) {
            inventory = new Inventory( );
            equipment = new Equipment( );
            dataHandler = new DataManager( inventory , equipment );
            ui_equipment.Equipment = player.Equipment;
            LoadInventory( );
      }
      private void LoadInventory( ) {
            dataHandler = dataHandler.LoadInventory( );
            equipment_so.EquipmentSlots = dataHandler.Equipment.EquipmentSlots;
            inventory_so.Items = dataHandler.Inventory.InventorySlots;
      }
      private void Start( ) {
            ui_Inventory.slotClicked += Ui_Inventory_onItemLeftClicked;
            ui_equipment.ItemClicked += Ui_equipment_ItemClicked;
      }
      private void Ui_equipment_ItemClicked( UI_EquipmentSlot item , PointerEventData eventData ) {
            if ( eventData.button == PointerEventData.InputButton.Left ) {
                  var equipmentType = item.Item.Type; 
                  inventory_so.AddItem( item.Item );
                  equipment_so.RemoveItem( equipmentType );
            }
      }

      private void Ui_Inventory_onItemLeftClicked( UI_InventorySlot slot , PointerEventData eventData ) {
            if ( eventData.button == PointerEventData.InputButton.Right ) {

                  var itemWorld = (GameObject)Instantiate(Resources.Load(slot.Item.name),
                     (Vector2)player.gameObject.transform.position + dropOffset,
                     Quaternion.identity);

                  var itemWorldSO = itemWorld.GetComponent<ItemWorld>().Item;
                  itemWorldSO.Amount = slot.Amount;
                  inventory_so.RemoveItem( slot.ID );

            }
            else if ( eventData.button == PointerEventData.InputButton.Left ) {
                  if ( !slot.Item.Stackable ) {
                        var item = inventory_so.Items[slot.ID].Item;
                        if ( equipment_so.SetItem( item ) )
                              inventory_so.RemoveItem( slot.ID );                      
                  }
                  else
                        inventory_so.UseItem( slot.Item );

            }

      }
      public void Save( ) {
            inventory.InventorySlots = inventory_so.Items;
            equipment.EquipmentSlots = equipment_so.EquipmentSlots;
            dataHandler.Save( );

      }
      public void OpenClose( ) {
            if ( inventoryObject.activeSelf )
                  inventoryObject.SetActive( false );
            else
                  inventoryObject.SetActive( true );
      }
      private void OnApplicationQuit( ) {
            inventory_so.Items.Clear( );
            foreach ( var equipItem in equipment_so.EquipmentSlots ) {
                  equipItem.Item = null;
            }
      }


}


