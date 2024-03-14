using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale.Patches;

[HarmonyPatch(typeof(GenericListener))]
public static class GenericListenerPatch
{
    [HarmonyPostfix]
    [HarmonyPatch("OnDataEvent")]
    private static void ProcessDataEvent(GenericListener __instance, ref Buffer ___readBuffer)
    {
        if (__instance is not ServerListener) return;
        if (___readBuffer.content[0] != BattleRoyale.CustomPackageByte) return;
        
        BattleRoyale.Logger.LogDebug("Server received custom package");
        
        if (___readBuffer.content[1] != BattleRoyale.PlayerDamagePackageByte) return;
        
        BattleRoyale.Logger.LogDebug("Server received custom player damage package");
        
        ___readBuffer.StartRead();
        
        var playerLobbyId = ___readBuffer.GetInt();
        var amount = ___readBuffer.GetFloat();
        var dmg = new Damage(amount);

        BattleRoyale.Logger.LogDebug($"Server received {amount} DMG dealt to {playerLobbyId}");
        
        if (playerLobbyId == 0)
        {
            BattleRoyale.Logger.LogDebug("Server is dealing damage to host");
            MultiplayerController.instance.GetMySlottedPlayer().playerObj.TakeDamage(dmg);
        }
        else
        {
            BattleRoyale.Logger.LogDebug($"Server is synchronizing player damage to {playerLobbyId}");
            ServerController.instance.GetSpeaker.SyncPlayerDamage(dmg, playerLobbyId);
        }
    }
}
