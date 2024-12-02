using Verse;

namespace MeleePsycasts;

public class CompProperties_AbilitySkewer : CompProperties_AbilityBasic
{
    public BodyPartDef torsoDef;

    public CompProperties_AbilitySkewer()
    {
        compClass = typeof(CompAbilityEffect_Skewer);
    }
}