using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(LoadoutSelector))]
public static class LoadoutSelectorPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("SelectedPreferredloadout")]
    public static bool PreventPreferredLoadout()
    {
        return false;
    }
}
