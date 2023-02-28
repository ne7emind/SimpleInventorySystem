
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour
{
      [SerializeField]
      GameObject _inventoryObject;

      [Header("Inventory")]
      [SerializeField]
      UI_Inventory _ui_Inventory;
      [Space]
      [SerializeField]
      Inventory_SO _inventory_so;

      Inventory _inventory;
      [Header("Equipment")]
      [SerializeField]
      UI_Equipment _ui_equipment;
      [Space]
      [SerializeField]
      Equipment_SO _equipment_so;

      Equipment _equipment;
      [Header("Player")]
      [SerializeField]
      Player _player;
      [Space]
      [SerializeField]
      Vector2 _dropOffset;
      IDataHandler dataHandler;
      private void Awake( ) {
            _inventory = new Inventory( );
            _equipment = new Equipment( );
            dataHandler = new DataManager( _inventory , _equipment );
            _ui_equipment.Equipment = _player.Equipment;
            LoadInventory( );
      }
      private void LoadInventory( ) {
            dataHandler = dataHandler.LoadInventory( );
            _equipment_so.EquipmentSlots = dataHandler.Equipment.EquipmentSlots;
            _inventory_so.Items = dataHandler.Inventory.InventorySlots;
      }
      private void Start( ) {
            _ui_Inventory.SlotClicked += Ui_Inventory_onItemLeftClicked;
            _ui_equipment.ItemClicked += Ui_equipment_ItemClicked;
      }
      private void Ui_equipment_ItemClicked( UI_EquipmentSlot item , PointerEventData eventData ) {
            if ( eventData.button == PointerEventData.InputButton.Left ) {
                  var equipmentType = item.Item.Type; 
                  _inventory_so.AddItem( item.Item );
                  _equipment_so.RemoveItem( equipmentType );
            }
      }

      private void Ui_Inventory_onItemLeftClicked( UI_InventorySlot slot , PointerEventData eventData ) {
            if ( eventData.button == PointerEventData.InputButton.Right ) {

                  var itemWorld = (GameObject)Instantiate(Resources.Load(slot.Item.name),
                     (Vector2)_player.gameObject.transform.position + _dropOffset,
                     Quaternion.identity);

                  var itemWorldSO = itemWorld.GetComponent<ItemWorld>().Item;
                  itemWorldSO.Amount = slot.Amount;
                  _inventory_so.RemoveItem( slot.ID );

            }
            else if ( eventData.button == PointerEventData.InputButton.Left ) {
                  if ( !slot.Item.Stackable ) {
                        var item = _inventory_so.Items[slot.ID].Item;
                        if ( _equipment_so.SetItem( item ) )
                              _inventory_so.RemoveItem( slot.ID );                      
                  }
                  else
                        _inventory_so.UseItem( slot.Item );

            }

      }
      public void Save( ) {
            _inventory.InventorySlots = _inventory_so.Items;
            _equipment.EquipmentSlots = _equipment_so.EquipmentSlots;
            dataHandler.Save( );

      }
      public void OpenClose( ) {
            if ( _inventoryObject.activeSelf )
                  _inventoryObject.SetActive( false );
            else
                  _inventoryObject.SetActive( true );
      }
      private void OnApplicationQuit( ) {
            _inventory_so.Items.Clear( );
            foreach ( var equipItem in _equipment_so.EquipmentSlots ) {
                  equipItem.Item = null;
            }
      }


}


