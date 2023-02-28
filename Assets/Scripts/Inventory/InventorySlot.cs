using UnityEngine;

[System.Serializable]
public class InventorySlot
{
      [SerializeField]
      Item_SO _item;
      public Item_SO Item { get { return _item; } }
      [SerializeField]
      int _amount;
      public int Amount { get { return _amount; } set { _amount = value; } }
      public InventorySlot(Item_SO item, int amount ) {
            this._item = item;
            this._amount = amount;
      }
}
