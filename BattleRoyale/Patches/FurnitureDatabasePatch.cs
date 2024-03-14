using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(FurnitureDatabase))]
public static class FurnitureDatabasePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(FurnitureDatabase.GetFurniturePrefab))]
    public static void SwapFurniture(ref Furniture.ID id)
    {
        id = id switch
        {
            Furniture.ID.DeadGuySitting => Furniture.ID.Broom,
            Furniture.ID.DeadGuyInTheFloor => Furniture.ID.DogFood,
            _ => id
        };
    }
}
