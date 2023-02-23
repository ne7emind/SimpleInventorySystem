using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class UI_EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
      [SerializeField]
      Image itemSprite;
      [SerializeField]
      Item_SO item;
      public int ID { get; set; }

      public event Action<UI_EquipmentSlot, PointerEventData> ItemClicked;
      public void SetItem(Item_SO item ) {
            this.item = item;
            if ( item == null ) {
                  itemSprite.enabled = false;
                  return;
            }         
            itemSprite.enabled = true;
            itemSprite.sprite = item.sprite;
      }
      public Item_SO GetItem( ) {
            return this.item;
      }

      public void OnPointerClick( PointerEventData eventData ) {
            ItemClicked?.Invoke( this, eventData );
      }
}
