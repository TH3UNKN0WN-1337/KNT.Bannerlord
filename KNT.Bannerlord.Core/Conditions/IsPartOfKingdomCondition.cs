using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace KNT.Bannerlord.Core.Conditions;

public class IsPartOfKingdomCondition : Condition<IsPartOfKingdomCondition>
{
    private new static TextObject FailedReasonText => new("{=XXXXX}{CHARACTER_NAME} has not enough {GOLD_ICON}.");

    public static bool Apply(Hero hero, out TextObject? failedReasonText)
    {
        return ApplyInternal(hero, out failedReasonText);
    }

    public static bool Apply(Clan clan, out TextObject? failedReasonText)
    {
        return ApplyInternal(clan.Leader, out failedReasonText);
    }

    public static bool Apply(IFaction faction, out TextObject? failedReasonText)
    {
        return ApplyInternal(faction.Leader, out failedReasonText);
    }

    private static bool ApplyInternal(Hero hero, out TextObject? failedReasonText)
    {
        failedReasonText = null;

        var isPartOfKingdom = hero.Clan.MapFaction.IsKingdomFaction;
        if (!isPartOfKingdom)
        {
            failedReasonText = FailedReasonText;
            failedReasonText.SetTextVariable("CHARACTER_NAME", hero.CharacterObject.Name);
        }

        return isPartOfKingdom;
    }
}