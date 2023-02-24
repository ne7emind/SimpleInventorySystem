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
      public event Action<UI_EquipmentSlot, PointerEventData> ItemClicked;
      public Item_SO Item {
            get {
                  return this.item;
            }
            set {
                  item = value; 
                  if ( value == null ) {
                        itemSprite.enabled = false;
                        return;
                  }
                  itemSprite.enabled = true;
                  itemSprite.sprite = item.sprite;
            }
      }

      public void OnPointerClick( PointerEventData eventData ) {
            if(item != null)
            ItemClicked?.Invoke( this, eventData );
      }
}
