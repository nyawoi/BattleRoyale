using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(Shot))]
public static class ShotPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Shot.SetupFirstStep))]
    public static void RemoveStagger(Shot __instance, Damage dmg)
    {
        dmg.stagger.staggerPackID = StaggerPack.ID.None;
        __instance.alreadyHitTarget.Add(dmg.sourcePlayer);
    }
}
