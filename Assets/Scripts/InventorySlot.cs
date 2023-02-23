using UnityEngine;

[System.Serializable]
public class InventorySlot
{
      [SerializeField]
      Item_SO item;
      public Item_SO Item { get { return item; } }
      [SerializeField]
      int amount;
      public int Amount { get { return amount; } set { amount = value; } }
      public InventorySlot(Item_SO item, int amount ) {
            this.item = item;
            this.amount = amount;
      }
}
