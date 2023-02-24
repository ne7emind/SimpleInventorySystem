using UnityEngine;

[CreateAssetMenu(fileName = "Armour", menuName = "Items / Armour")]
public class Armour_SO : Equipable_SO
{      
      private void Awake( ) {
            Type = ItemType.armour;
      }
}
