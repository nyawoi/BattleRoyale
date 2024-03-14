using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(LoadoutSelectionSlotUI))]
public static class LoadoutSelectionSlotUIPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(LoadoutSelectionSlotUI.SelectBack))]
    [HarmonyPatch(nameof(LoadoutSelectionSlotUI.SelectForward))]
    public static bool DisableButtons()
    {
        return false;
    }
}
