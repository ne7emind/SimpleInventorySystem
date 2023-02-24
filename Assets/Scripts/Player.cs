using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{

      [SerializeField]
      Equipment_SO equipment;
      public Equipment_SO Equipment { get => equipment; }
      [SerializeField]
      Inventory_SO inventory;
      [SerializeField]
      float speed;
      [SerializeField]
      int armor;
      [SerializeField]
      int attack;
      [SerializeField]
      int healthPoints = 100;
      [SerializeField]
      int manaPoints = 100;


      private void Start( ) {
            if ( equipment != null ) {
                  equipment.ItemEquiped += EquipItem;
                  equipment.ItemUnequiped += UnequipItem;
                  foreach ( var item in equipment.EquipmentSlots ) {
                        EquipItem( item.Item );
                  }
            }
      }
      private void OnValidate( ) {
            //EquipItem( );
      }
      private void Update( ) {
            Move( );
      }
      private void Move( ) {
            float x = Input.GetAxis( "Horizontal" );
            transform.Translate( Vector3.right * x * speed );
      }
      private void OnTriggerEnter2D( Collider2D collision ) {
            if ( collision.gameObject.tag == "Item" )
                  PickItemFromGround( collision.gameObject );
      }

      private void PickItemFromGround( GameObject obj ) {
            inventory.AddItem( obj.GetComponent<ItemWorld>( ).Item);
            obj.TryGetComponent<IDestroyable>( out IDestroyable destroyable );
            destroyable.Destroy( );
      }
      public void EquipItem(Item_SO item) {
            if ( equipment != null && item != null) {
                  var equipItem = ( Equipable_SO ) item;
                  armor += equipItem.Armor;
                  healthPoints += equipItem.Health;
                  attack += equipItem.Attack;
                  manaPoints += equipItem.Mana;
            }
      }
      public void UnequipItem(Item_SO item ) {
            if ( equipment != null ) {
                  var equipItem = ( Equipable_SO ) item;
                  armor -= equipItem.Armor;
                  healthPoints -= equipItem.Health;
                  attack -= equipItem.Attack;
                  manaPoints -= equipItem.Mana;
            }
      }
}
