using UnityEngine;

[CreateAssetMenu( fileName = "Ring" , menuName = "Items / Ring" )]
public class Ring_SO : NonStackable_SO
{
      private void Awake( ) {
            Type = ItemType.ring;
      }
}