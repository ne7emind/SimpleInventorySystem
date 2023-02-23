using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 public class ItemWorld : MonoBehaviour, IDestroyable
{
      [SerializeField]
      Item_SO item;
      public Item_SO Item { get { return item; } }

      private void OnValidate( ) {
            if ( item == null )
                  return;
            GetComponent<SpriteRenderer>().sprite = item.sprite;
            gameObject.name = item.name;
      }
      public void Destroy( ) {
            Destroy( gameObject );
      }

}

public interface IDestroyable
{
      void Destroy();
}
