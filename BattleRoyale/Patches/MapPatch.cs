using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(Map))]
public static class MapPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Map.Init))]
    public static void ChangeMapSize(Map __instance)
    {
        // Default map size: (20,20)
        __instance.defMapSize.x = __instance.defMapSize.y = 10;
    }
}
