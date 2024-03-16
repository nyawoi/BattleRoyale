using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(PlayerMovement))]
public static class PlayerMovementPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(PlayerMovement.TryStagger))]
    public static bool DisableStaggering()
    {
        return true;
    }
}
