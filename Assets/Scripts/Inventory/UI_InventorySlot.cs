using System;
using System.Collections;

using TMPro;

using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventorySlot : MonoBehaviour, IPointerClickHandler
{

      [SerializeField]
      Image _itemSprite;
      [SerializeField]
      TMP_Text _amountText;
      [SerializeField]
      Item_SO _item;
      public int ID { get; set; }
      public int Amount { get; set; }
      public virtual Item_SO Item { get { return _item; } set { _item = value; } }

      public event Action<UI_InventorySlot, PointerEventData> SlotClicked;

      public void OnPointerClick( PointerEventData eventData ) {
            SlotClicked?.Invoke( this , eventData );
      }
      private void OnValidate( ) {
            _itemSprite = transform.GetChild( 0 ).GetComponent<Image>( );
            _amountText = transform.GetChild( 1 ).GetComponent<TMP_Text>( );
      }

      public virtual void Start( ) {
            _itemSprite.sprite = _item.sprite;
            if ( !_item.Stackable )
                  return;
            _amountText.text = Amount.ToString( );

      }
}
