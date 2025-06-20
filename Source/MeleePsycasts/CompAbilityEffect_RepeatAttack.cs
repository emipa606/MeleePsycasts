using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_RepeatAttack : BaseCompAbilityEffect
{
    private CompProperties_AbilityRepeatAttack abilityProps;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        abilityProps = (CompProperties_AbilityRepeatAttack)Props;

        if (target.Pawn == null || abilityProps == null)
        {
            return;
        }

        MeleePsycastsUtils.DamageRandomBodyPart(abilityProps, parent.pawn, target.Pawn, abilityProps.repeatAmount);
    }

    public override bool GizmoDisabled(out string reason)
    {
        abilityProps = (CompProperties_AbilityRepeatAttack)Props;

        if (abilityProps == null)
        {
            reason = string.Empty;
            return false;
        }

        if (abilityProps.requiresMelee)
        {
            return base.GizmoDisabled(out reason);
        }

        reason = string.Empty;
        return false;
    }
}