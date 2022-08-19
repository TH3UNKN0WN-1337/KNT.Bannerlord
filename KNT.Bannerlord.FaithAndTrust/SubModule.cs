using HarmonyLib;
using System.ComponentModel;
using Bannerlord.UIExtenderEx;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace KNT.Bannerlord.FaithAndTrust;

public sealed class SubModule : MBSubModuleBase
{
    private string Namespace => typeof(SubModule).Namespace;

    protected override void OnSubModuleLoad()
    {
        new Harmony(Namespace).PatchAll();

        var uiExtender = new UIExtender(Namespace);
        uiExtender.Register(typeof(SubModule).Assembly);
        uiExtender.Enable();

    }

    protected override void OnSubModuleUnloaded()
    {
        new Harmony(Namespace).UnpatchAll(Namespace);
    }

    protected override void OnGameStart(Game game, IGameStarter gameStarter)
    {
        if (gameStarter is not CampaignGameStarter campaignStarter)
        {
            return;
        }
    }
}