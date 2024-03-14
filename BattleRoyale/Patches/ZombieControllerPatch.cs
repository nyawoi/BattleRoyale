using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(ZombieController))]
public static class ZombieControllerPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(ZombieController.InitZombies))]
    [HarmonyPatch(nameof(ZombieController.GenerateZombiePositions))]
    [HarmonyPatch(nameof(ZombieController.CalculateCellZombieCount))]
    public static bool DisableZombies(ZombieController __instance)
    {
        __instance.disableZombies = true;
        return false;
    }
}
