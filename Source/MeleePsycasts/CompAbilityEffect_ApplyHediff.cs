using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_ApplyHediff : BaseCompAbilityEffect
{
    private CompProperties_AbilityApplyHediff abilityProps;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        abilityProps = (CompProperties_AbilityApplyHediff)Props;

        if (target.Pawn == null || abilityProps == null)
        {
            return;
        }

        target.Pawn?.health.AddHediff(HediffMaker.MakeHediff(abilityProps.hediffDef, target.Pawn));
    }

    public override bool GizmoDisabled(out string reason)
    {
        abilityProps = (CompProperties_AbilityApplyHediff)Props;

        if (abilityProps == null)
        {
            reason = "";
            return false;
        }

        if (abilityProps.requiresMelee)
        {
            return base.GizmoDisabled(out reason);
        }

        reason = "";
        return false;
    }
}