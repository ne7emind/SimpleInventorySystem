using UnityEngine;

[CreateAssetMenu(fileName = "Armour", menuName = "Items / Armour")]
public class Armour_SO : NonStackable_SO
{
      private void Awake( ) {
            Type = ItemType.armour;
      }
}
