using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
      [SerializeField]
      GameObject inventoryObject;
      [SerializeField]
      UI_Inventory ui_inventory;
      [SerializeField]
      Inventory_SO inventory;
      [SerializeField]
      float speed;
      

      private void Start( ) {
           
      }
      private void Update( ) {

            if ( Input.GetKeyDown( KeyCode.Space ) ) {
                  if ( inventoryObject.activeSelf )
                        inventoryObject.SetActive( false );
                  else {
                        inventoryObject.SetActive( true );

                  }
            }
            if ( Input.GetKeyDown( KeyCode.S ) ) {
               
            }


            Move( );
      }
      private void Move( ) {
            float x = Input.GetAxis( "Horizontal" );
            transform.Translate( Vector3.right * x * speed );
      }
      private void OnTriggerEnter2D( Collider2D collision ) {
            if ( collision.gameObject.tag == "Item" )
                  AddItemToInventory( collision.gameObject );
      }



      private void AddItemToInventory( GameObject obj ) {

            inventory.AddItem( obj.GetComponent<ItemWorld>( ).Item);
            obj.TryGetComponent<IDestroyable>( out IDestroyable destroyable );
            destroyable.Destroy( );
      }
}
