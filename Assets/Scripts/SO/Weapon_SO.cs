using UnityEngine;

[CreateAssetMenu( fileName = "Weapon" , menuName = "Items / Weapon" )]
public class Weapon_SO : Equipable_SO
{
      private void Awake( ) {
            Type = ItemType.weapon;
      }
}
