using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(ZBMain))]
public static class ZBMainPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(ZBMain.Start))]
    public static void GameModeVersion(ZBMain __instance)
    {
        __instance.versionText.text = $"Zumbi Blocks 2 (BattleRoyale) [v{BattleRoyale.PluginVersion}]";
    }
}
