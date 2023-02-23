abstract public class Stackable_SO : Item_SO
{          
      private void OnValidate( ) {
            Stackable = true;
            
      }
}
abstract public class NonStackable_SO : Item_SO
{
      private void OnValidate( ) {
            Stackable = false;
            Amount = 1;
      }
}
