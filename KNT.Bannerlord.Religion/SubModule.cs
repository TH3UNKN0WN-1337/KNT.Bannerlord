using System;
using System.Collections.Generic;
using System.Linq;
using Bannerlord.ButterLib.MBSubModuleBaseExtended;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace KNT.Bannerlord.Religion;

public class SubModule : MBSubModuleBaseEx
{
    private Type[]? _types;

    protected override void OnSubModuleLoad()
    {
        base.OnSubModuleLoad();

        _types = typeof(SubModule).Assembly.GetTypes();
        new Harmony("KNT.Bannerlord.Religion").PatchAll();
    }

    protected override void InitializeGameStarter(Game game, IGameStarter starterObject)
    {
        base.InitializeGameStarter(game, starterObject);

        if (starterObject is CampaignGameStarter campaignGameStarter)
        {
            AddCampaignBehaviors(campaignGameStarter);
        }

        AddGameModels(starterObject);
    }

    public override void OnMissionBehaviorInitialize(Mission mission)
    {
        base.OnMissionBehaviorInitialize(mission);

        AddMissionBehaviors(mission);
        AddMissionViews(mission);
    }

    private void AddCampaignBehaviors(CampaignGameStarter campaignGameStarter)
    {
        var campaignBehaviors = GetTypesOf<CampaignBehaviorBase>();
        foreach (var campaignBehavior in campaignBehaviors)
        {
            campaignGameStarter.AddBehavior((CampaignBehaviorBase) Activator.CreateInstance(campaignBehavior));
        }
    }

    private void AddGameModels(IGameStarter campaignGameStarter)
    {
        var gameModels = GetTypesOf<GameModel>();
        foreach (var gameModel in gameModels)
        {
            campaignGameStarter.AddModel((GameModel) Activator.CreateInstance(gameModel));
        }
    }

    private void AddMissionBehaviors(Mission mission)
    {
        var missionBehaviors = GetTypesOf<MissionBehavior>();
        foreach (var missionBehavior in missionBehaviors)
        {
            mission.AddMissionBehavior((MissionBehavior) Activator.CreateInstance(missionBehavior));
        }
    }

    private void AddMissionViews(Mission mission)
    {
        var missionViews = GetTypesOf<MissionView>();
        foreach (var missionView in missionViews)
        {
            mission.AddMissionBehavior((MissionView) Activator.CreateInstance(missionView));
        }
    }

    private IEnumerable<Type> GetTypesOf<T>()
    {
        return _types!.Where(type => type.IsAssignableFrom(typeof(T)));
    }
}