using System;
using System.Collections.Generic;
using UnityEngine;

abstract public class Inventory_SO : ScriptableObject
{
      [SerializeField]
      List<InventorySlot> items = new List<InventorySlot>();
      public List<InventorySlot> GetItems( ) {
            return items;
      }
      public void SetItems( List<InventorySlot> items ) {
            this.items = items;
      }

      public event Action itemChanged;
     // public event Action<string, int> itemRemoved;

      public void RemoveItem( Item_SO item) {
            for ( int i = 0 ; i < items.Count ; i++ ) {
                  if ( items[ i ].Item == item ) {
                        int amount = items[i].Amount;
                        items.RemoveAt( i );
                        itemChanged?.Invoke( );                                            //  itemRemoved?.Invoke( item.name , amount );
                        
                  }
            }
      }
      public void AddItem( Item_SO item ) {
            bool hasItem = false;
            if ( item is Stackable_SO ) {
                  for ( int i = 0 ; i < items.Count ; i++ ) {
                        if ( items[ i ].Item == item ) {
                              items[ i ].Amount++;
                              hasItem = true;
                              break;
                        }
                  }
            }
            if ( !hasItem ) {
                  items.Add( new InventorySlot( item , item.Amount ) );                 
            }

            itemChanged?.Invoke( );
      }
      
      public void UseItem( Item_SO item ) {
            for ( int i = 0 ; i < items.Count ; i++ ) {
                  if ( items[ i ].Item == item ) {
                        items[ i ].Amount--;
                        if ( items[ i ].Amount <= 0 ) {
                              items.RemoveAt( i );                            
                        }
                        itemChanged?.Invoke( );
                        return;
                  }
            }
      }

}
