using HarmonyLib;
using UnityEngine;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(LootController))]
public static class LootControllerPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(LootController.GetLootID))]
    public static void IncreaseTier(ref int tier)
    {
        // Tier 0 - 60%
        // Tier 1 - 25%
        // Tier 2 - 15%
        tier = Random.value switch
        {
            <= 0.15f => 2,
            <= 0.40f => 1,
            _ => 0
        };
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(LootController.Init))]
    public static void IncreaseMultiplier(LootController __instance)
    {
        __instance.lootCountMultiplier = 0.25f;
    }
}
