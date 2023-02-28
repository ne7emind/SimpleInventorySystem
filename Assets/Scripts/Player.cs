
using UnityEngine;

public class Player : MonoBehaviour
{
      [Header("Equipment")]
      [SerializeField]
      Equipment_SO _equipment;
      public Equipment_SO Equipment { get => _equipment; }
      [Header("Inventory")]
      [SerializeField]
      Inventory_SO _inventory;
      [Space]
      [SerializeField]
      float _speed;
      [Space]
      [SerializeField]
      int _armor;
      [Space]
      [SerializeField]
      int _attack;
      [Space]
      [SerializeField]
      int _healthPoints = 100;
      [Space]
      [SerializeField]
      int _manaPoints = 100;


      private void Start( ) {
            if ( _equipment != null ) {
                  _equipment.ItemEquiped += EquipItem;
                  _equipment.ItemUnequiped += UnequipItem;
                  foreach ( var item in _equipment.EquipmentSlots ) {
                        EquipItem( item.Item );
                  }
            }
      }
      private void Update( ) {
            Move( );
      }
      private void Move( ) {
            float x = Input.GetAxis( "Horizontal" );
            transform.Translate( Vector3.right * x * _speed );
      }
      private void OnTriggerEnter2D( Collider2D collision ) {
            if ( collision.gameObject.tag == "Item" )
                  PickItemFromGround( collision.gameObject );
      }

      private void PickItemFromGround( GameObject obj ) {
            _inventory.AddItem( obj.GetComponent<ItemWorld>( ).Item);
            obj.TryGetComponent<IDestroyable>( out IDestroyable destroyable );
            destroyable.Destroy( );
      }
      public void EquipItem(Item_SO item) {
            if ( _equipment != null && item != null) {
                  var equipItem = ( Equipable_SO ) item;
                  _armor += equipItem.Armor;
                  _healthPoints += equipItem.Health;
                  _attack += equipItem.Attack;
                  _manaPoints += equipItem.Mana;
            }
      }
      public void UnequipItem(Item_SO item ) {
            if ( _equipment != null ) {
                  var equipItem = ( Equipable_SO ) item;
                  _armor -= equipItem.Armor;
                  _healthPoints -= equipItem.Health;
                  _attack -= equipItem.Attack;
                  _manaPoints -= equipItem.Mana;
            }
      }
}
