using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(EntityUIIconController))]
public static class EntityUIIconControllerPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(EntityUIIconController.UpdateDisplay))]
    public static bool PreventDisplay()
    {
        return false;
    }
}
