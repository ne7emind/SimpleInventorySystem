public interface IDataHandler
{
      void Save( );
      DataManager LoadInventory( );
      Equipment Equipment { get; }
      Inventory Inventory { get; } 
    //  Equipment LoadEquipment( );
}