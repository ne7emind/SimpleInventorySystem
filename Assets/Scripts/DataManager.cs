using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IDataHandler
{
      [SerializeField]
      Inventory inventory;
      public Inventory Inventory { get { return inventory; } }
      
      public DataManager(Inventory inventory) {
            this.inventory = inventory;
      }

      public Inventory Load( ) {
             
            if ( PlayerPrefs.HasKey( "inventory" ) ) {
                  string data = PlayerPrefs.GetString("inventory");
                  return JsonUtility.FromJson<Inventory>( data );                              
            }
            return inventory;
                           
      }

      public void Save( ) {
            string json = JsonUtility.ToJson( inventory );
            PlayerPrefs.DeleteAll( );
            PlayerPrefs.SetString( "inventory" , json );
            Debug.Log( json );
      }
}
public interface IDataHandler
{
      void Save( );
      Inventory Load( );
}