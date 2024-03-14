using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(ItemsBase))]
public static class ItemsBasePatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(ItemsBase.Init))]
    public static void IncreaseHealing(ItemsBase __instance)
    {
        foreach (var item in __instance.item)
        {
            if (item is DatabaseConsumable { ishealing: true } consumable)
            {
                consumable.effectAmount *= 6;
            }
        }
    }
}
