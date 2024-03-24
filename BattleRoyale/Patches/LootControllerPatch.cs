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

        var enhancedTier = __instance.gameObject.AddComponent<TierLootDistribution>();
        enhancedTier.equipmentRarity = 0.1f;
        enhancedTier.equipment = new TierLootDistribution.LootChance[]
        {
            new()
            {
                itemID = InventoryItem.ID.Mossberg590,
                probability = 50
            },
            new()
            {
                itemID = InventoryItem.ID.VectorTactical,
                probability = 10
            },
            new()
            {
                itemID = InventoryItem.ID.RiotShotgun,
                probability = 25
            },
            new()
            {
                itemID = InventoryItem.ID.QueensHammer,
                probability = 25
            },
            new()
            {
                itemID = InventoryItem.ID.Pickaxe,
                probability = 20
            },
            new()
            {
                itemID = InventoryItem.ID.Nodachi,
                probability = 15
            }
        };
        enhancedTier.resources = new TierLootDistribution.LootChance[]
        {
            new()
            {
                itemID = InventoryItem.ID.Painkiller,
                probability = 15
            },
            new()
            {
                itemID = InventoryItem.ID.DovesCake,
                probability = 10
            }
        };
        __instance.lootDistro.tier[2] = enhancedTier;
    }
}
