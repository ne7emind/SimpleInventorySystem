using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class UI_EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
      [SerializeField]
      Image _itemSprite;
      [SerializeField]
      Item_SO _item; 
      public event Action<UI_EquipmentSlot, PointerEventData> ItemClicked;
      public Item_SO Item {
            get {
                  return this._item;
            }
            set {
                  _item = value; 
                  if ( value == null ) {
                        _itemSprite.enabled = false;
                        return;
                  }
                  _itemSprite.enabled = true;
                  _itemSprite.sprite = _item.sprite;
            }
      }
      private void OnValidate( ) {
            _itemSprite = transform.GetChild( 0 ).GetComponent<Image>();

      }

      public void OnPointerClick( PointerEventData eventData ) {
            if(_item != null)
            ItemClicked?.Invoke( this, eventData );
      }
}
