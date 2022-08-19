using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace KNT.Bannerlord.Core.Conditions;

public sealed class HasEnoughGoldCondition : Condition<HasEnoughGoldCondition>
{
    private new static TextObject FailedReasonText => GameTexts.FindText("str_condition.has_enough_gold");

    public static bool Apply(Hero hero, int coast, out TextObject? failedReasonText)
    {
        return ApplyInternal(hero, coast, out failedReasonText);
    }

    public static bool Apply(Clan clan, int coast, out TextObject? failedReasonText)
    {
        return ApplyInternal(clan.Leader, coast, out failedReasonText);
    }

    public static bool Apply(Kingdom kingdom, int coast, out TextObject? failedReasonText)
    {
        return ApplyInternal(kingdom.Leader, coast, out failedReasonText);
    }

    public static bool Apply(IFaction faction, int coast, out TextObject? failedReasonText)
    {
        return ApplyInternal(faction.Leader, coast, out failedReasonText);
    }

    private static bool ApplyInternal(Hero hero, int coast, out TextObject? failedReasonText)
    {
        failedReasonText = null;

        var hasEnoughGold = hero.Gold >= coast;
        if (!hasEnoughGold)
        {
            failedReasonText = FailedReasonText;
            StringHelpers.SetCharacterProperties("PAYER", hero.CharacterObject, failedReasonText);
        }

        return hasEnoughGold;
    }
}