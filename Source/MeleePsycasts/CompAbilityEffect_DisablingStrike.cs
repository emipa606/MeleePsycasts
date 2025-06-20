using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_DisablingStrike : BaseCompAbilityEffect
{
    private CompProperties_AbilityBasic abilityProps;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        abilityProps = (CompProperties_AbilityBasic)Props;

        if (target.Pawn == null || abilityProps == null)
        {
            return;
        }

        MeleePsycastsUtils.DamageRandomBodyPart(abilityProps, parent.pawn, target.Pawn, 3);

        MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, "MePs.Disable".Translate(), 3f);
    }

    public override bool GizmoDisabled(out string reason)
    {
        reason = "MePs.DisableNoMelee".Translate();
        return false;
    }
}