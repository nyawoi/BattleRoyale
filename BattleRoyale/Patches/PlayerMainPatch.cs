using HarmonyLib;
using UnityEngine;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(PlayerMain))]
public static class PlayerMainPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("Start")]
    public static void ModifyPlayer(PlayerMain __instance)
    {
        __instance.arms.shotLayerMask = LayerMask.GetMask("Default", "Player", "Geometry", "BulletsCollider");
        __instance.movement.walkSpeed *= 1.15f;
        
        __instance.maxHealth *= 4;
        __instance.healthFast = __instance.maxHealth;
        __instance.healthSlow = __instance.maxHealth;
        
        __instance.maxStamina *= 2;
        __instance.staminaFast = __instance.maxStamina;
        __instance.staminaSlow = __instance.maxStamina;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(PlayerMain.TakeDamage))]
    public static bool SynchronizeDamage(PlayerMain __instance, ref Damage dmg)
    {
        if (MultiplayerController.instance.IsServer() || !__instance.ForeignPlayer) return true;
        
        BattleRoyale.SendPlayerDamage(dmg, __instance.lobbyPlayer.lobbyID);
        
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(PlayerMain.respawnTime), MethodType.Getter)]
    public static bool QuickerRespawn(ref float __result)
    {
        __result = 3f;
        return false;
    }
    
    [HarmonyPostfix]
    [HarmonyPatch("ProcessHealth")]
    public static void SkipDyingPhase(PlayerMain __instance)
    {
        if (__instance.healthState == PlayerMain.HealthState.Dying)
        {
            AccessTools
                .Method(__instance.GetType(), "DieForGood")
                .Invoke(__instance, new object[]{});
        }
    }
}
