using Verse;

namespace MeleePsycasts;

public class CompProperties_AbilityApplyHediff : CompProperties_AbilityBasic
{
    public HediffDef hediffDef;
    public bool requiresMelee = true;

    public CompProperties_AbilityApplyHediff()
    {
        compClass = typeof(CompAbilityEffect_ApplyHediff);
    }
}