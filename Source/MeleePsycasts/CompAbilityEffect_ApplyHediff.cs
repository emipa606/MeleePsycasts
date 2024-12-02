using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_ApplyHediff : BaseCompAbilityEffect
{
    private CompProperties_AbilityApplyHediff _Props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        _Props = (CompProperties_AbilityApplyHediff)Props;

        if (target.Pawn == null || _Props == null)
        {
            return;
        }

        target.Pawn?.health.AddHediff(HediffMaker.MakeHediff(_Props.hediffDef, target.Pawn));
    }

    public override bool GizmoDisabled(out string reason)
    {
        _Props = (CompProperties_AbilityApplyHediff)Props;

        if (_Props == null)
        {
            reason = "";
            return false;
        }

        if (_Props.requiresMelee)
        {
            return base.GizmoDisabled(out reason);
        }

        reason = "";
        return false;
    }
}