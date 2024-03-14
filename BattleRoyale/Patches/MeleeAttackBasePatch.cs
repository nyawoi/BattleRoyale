using HarmonyLib;
using UnityEngine;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(MeleeAttackBase))]
public static class MeleeAttackBasePatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(MeleeAttackBase.Init))]
    public static void ModifyAttack(MeleeAttackBase __instance)
    {
        __instance.meleeHitLayermask = LayerMask.GetMask("Default", "Player", "Geometry");
        __instance.dmgMultiplier = 4;
    }
}
