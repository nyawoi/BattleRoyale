using System.Reflection;
using BepInEx;
using HarmonyLib;
using BepInEx.Logging;

namespace AetharNet.Mods.ZumbiBlocks2.BattleRoyale;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class BattleRoyale : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.BattleRoyale";
    public const string PluginAuthor = "awoi";
    public const string PluginName = "BattleRoyale";
    public const string PluginVersion = "0.3.0";

    public new static ManualLogSource Logger;

    private void Awake()
    {
        Logger = base.Logger;

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
    }
    
    internal const byte CustomPackageByte = 254;
    internal const byte PlayerDamagePackageByte = 0;
    
    internal static void SendPlayerDamage(Damage dmg, int playerLobbyId)
    {
        Logger.LogDebug($"Client dealt {dmg.amount} DMG to {playerLobbyId}");
        
        var speaker = ClientController.instance.GetSpeaker;
        
        speaker.sendBuffer.StartWrite();
        // Custom Package
        speaker.sendBuffer.PushByte(CustomPackageByte);
        // Custom Player Damage Package (0)
        speaker.sendBuffer.PushByte(PlayerDamagePackageByte);
        // Pass our package body
        speaker.sendBuffer.PushInt(playerLobbyId);
        speaker.sendBuffer.PushFloat(dmg.amount);
        
        Logger.LogDebug("Client has created custom player damage package");
        
        AccessTools
            .Method(speaker.GetType(), "SendBuffer")
            .Invoke(speaker, new object[] { ServerController.PacketReliability.Reliable });
        
        Logger.LogDebug("Client is sending custom player damage package to server");
    }
}
