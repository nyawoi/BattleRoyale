using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(ThrowableInstance))]
public static class ThrowableInstancePatch
{
    [HarmonyPrefix]
    [HarmonyPatch("ProcessCollisionDamage")]
    public static void EnablePlayerDamage(ThrowableInstance __instance)
    {
        __instance.throwingPlayer = null;
    }
}
