using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace KNT.Bannerlord.Core.Conditions;

public abstract class Condition<T> where T : Condition<T>, new()
{
    protected static TextObject FailedReasonText => GameTexts.FindText("str_common_placeholder");
}