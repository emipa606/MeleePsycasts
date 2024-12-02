using Verse;

namespace MeleePsycasts;

public class CompProperties_AbilityAttackLimb : CompProperties_AbilityBasic
{
    public readonly string successMessage = "";
    public BodyPartDef limbDef;

    public CompProperties_AbilityAttackLimb()
    {
        compClass = typeof(CompAbilityEffect_AttackLimb);
    }
}