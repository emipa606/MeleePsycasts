using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_RepeatAttack : BaseCompAbilityEffect
{
    private CompProperties_AbilityRepeatAttack _Props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        _Props = (CompProperties_AbilityRepeatAttack)Props;

        if (target.Pawn == null || _Props == null)
        {
            return;
        }

        MeleePsycastsUtils.DamageRandomBodyPart(_Props, parent.pawn, target.Pawn, _Props.repeatAmount);
    }

    public override bool GizmoDisabled(out string reason)
    {
        _Props = (CompProperties_AbilityRepeatAttack)Props;

        if (_Props == null)
        {
            reason = string.Empty;
            return false;
        }

        if (_Props.requiresMelee)
        {
            return base.GizmoDisabled(out reason);
        }

        reason = string.Empty;
        return false;
    }
}