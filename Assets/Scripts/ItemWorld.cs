
using UnityEngine;
 public class ItemWorld : MonoBehaviour, IDestroyable
{
      [SerializeField]
      Item_SO _item;
      public Item_SO Item { get { return _item; } }

      private void OnValidate( ) {
            if ( _item == null )
                  return;
            GetComponent<SpriteRenderer>().sprite = _item.sprite;
            gameObject.name = _item.name;
      }
      public void Destroy( ) {
            Destroy( gameObject );
      }

}

public interface IDestroyable
{
      void Destroy();
}
