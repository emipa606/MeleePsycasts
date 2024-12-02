using Verse;

namespace MeleePsycasts;

public class CompProperties_AbilityLegCut : CompProperties_AbilityBasic
{
    public BodyPartDef legDef;

    public CompProperties_AbilityLegCut()
    {
        compClass = typeof(CompAbilityEffect_LegCut);
    }
}