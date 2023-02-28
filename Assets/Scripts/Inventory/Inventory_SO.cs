using System;
using System.Collections.Generic;
using UnityEngine;

abstract public class Inventory_SO : ScriptableObject
{
      [SerializeField]
      List<InventorySlot> _items = new List<InventorySlot>();

      public List<InventorySlot> Items { get => _items; set => _items = value; } 

      public event Action ItemChanged;
     // public event Action<string, int> itemRemoved;

      public void RemoveItem( int index) {
        /*    for ( int i = 0 ; i < items.Count ; i++ ) {
                  if ( items[ i ].Item == item ) {
                        int amount = items[i].Amount;
                        items.RemoveAt( i );
                        itemChanged?.Invoke( );                                            //  itemRemoved?.Invoke( item.name , amount );
                        
                  }
            }*/
            _items.RemoveAt(index);
            ItemChanged?.Invoke();
      }
      public void AddItem( Item_SO item ) {
            bool hasItem = false;
            if ( item is Stackable_SO ) {
                  for ( int i = 0 ; i < _items.Count ; i++ ) {
                        if ( _items[ i ].Item == item ) {
                              _items[ i ].Amount++;
                              hasItem = true;
                              break;
                        }
                  }
            }
            if ( !hasItem ) {
                  _items.Add( new InventorySlot( item , item.Amount ) );                 
            }

            ItemChanged?.Invoke( );
      }
      
      public void UseItem( Item_SO item ) {
            for ( int i = 0 ; i < _items.Count ; i++ ) {
                  if ( _items[ i ].Item == item ) {
                        _items[ i ].Amount--;
                        if ( _items[ i ].Amount <= 0 ) {
                              _items.RemoveAt( i );                            
                        }
                        ItemChanged?.Invoke( );
                        return;
                  }
            }
      }

}
