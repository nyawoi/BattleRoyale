using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(InterestPointController))]
public static class InterestPointControllerPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(InterestPointController.AddLoot))]
    [HarmonyPatch(nameof(InterestPointController.AddBoss))]
    public static bool DisablePoints()
    {
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(InterestPointController.UpdatePlayerPoint))]
    public static bool DisablePlayerPoints(InterestPoint point)
    {
        var player = point.objTransform.gameObject.GetComponent<PlayerMain>();
        
        if (player is null || player.lobbyPlayer is null) return false;
        
        return player.lobbyPlayer.lobbyID == MultiplayerController.instance.GetMyLobbyID();
    }
}
