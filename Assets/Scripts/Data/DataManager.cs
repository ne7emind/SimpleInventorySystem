using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IDataHandler
{
      [SerializeField]
      Inventory _inventory;
      [SerializeField]
      Equipment _equipment;
      public Inventory Inventory { get { return _inventory; } }
      public Equipment Equipment { get { return _equipment; } }
      
      public DataManager(Inventory inventory, Equipment equipment) {
            this._equipment= equipment;
            this._inventory = inventory;
      }

      public DataManager LoadInventory( ) {            
            if ( PlayerPrefs.HasKey( "inventory" ) ) {
                  string data = PlayerPrefs.GetString("inventory");
                  return JsonUtility.FromJson<DataManager>( data );                              
            }
            return this;                          
      }
    

      public void Save( ) {
            string json = JsonUtility.ToJson( this );
            PlayerPrefs.DeleteAll( );
            PlayerPrefs.SetString( "inventory" , json );
            Debug.Log( json );
      }
}
