using UnityEngine;

[CreateAssetMenu( fileName = "Weapon" , menuName = "Items / Weapon" )]
public class Weapon_SO : NonStackable_SO
{
      private void Awake( ) {
            Type = ItemType.weapon;
      }
}
