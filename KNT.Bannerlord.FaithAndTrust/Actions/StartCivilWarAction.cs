using System.Collections.Generic;
using KNT.Bannerlord.Core.Conditions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace KNT.Bannerlord.FaithAndTrust.Actions;

public static class StartCivilWarAction
{
    public static bool CanApply(Hero hero, out List<TextObject> failedReasonTexts)
    {
        failedReasonTexts = new List<TextObject>();

        if (!IsPartOfKingdomCondition.Apply(hero, out var isPartOfKingdomConditionFailedReasonText))
        {
            failedReasonTexts.Add(isPartOfKingdomConditionFailedReasonText!);
        }

        if (!HasEnoughGoldCondition.Apply(hero, 5000, out var hasEnoughGoldConditionFailedReasonText))
        {
            failedReasonTexts.Add(hasEnoughGoldConditionFailedReasonText!);
        }

        return failedReasonTexts.IsEmpty();
    }

    public static void Apply()
    {
        ApplyInternal();
    }

    private static void ApplyInternal()
    {
    }
}