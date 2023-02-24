using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventorySlot :MonoBehaviour, IPointerClickHandler
{

      [SerializeField]
      Image itemSprite;
      [SerializeField]
      TMP_Text amountText;
      [SerializeField]
      Item_SO item;
      public int ID { get; set; }
      public int Amount { get; set; }
      public virtual Item_SO Item { get { return item; } set { item = value; } }

      public event Action<UI_InventorySlot, PointerEventData> slotClicked;

      public void OnPointerClick( PointerEventData eventData ) {
            slotClicked?.Invoke( this , eventData );
      }

      public virtual void Start( ) {
            itemSprite.sprite = item.sprite;
            if ( !item.Stackable )
                  return;
            amountText.text = Amount.ToString( );

      }
}
