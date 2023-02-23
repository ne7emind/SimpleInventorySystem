using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IDataHandler
{
      [SerializeField]
      Inventory inventory;
      [SerializeField]
      Equipment equipment;
      public Inventory Inventory { get { return inventory; } }
      public Equipment Equipment { get { return equipment; } }
      
      public DataManager(Inventory inventory, Equipment equipment) {
            this.equipment= equipment;
            this.inventory = inventory;
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
public interface IDataHandler
{
      void Save( );
      DataManager LoadInventory( );
      Equipment Equipment { get; }
      Inventory Inventory { get; } 
    //  Equipment LoadEquipment( );
}