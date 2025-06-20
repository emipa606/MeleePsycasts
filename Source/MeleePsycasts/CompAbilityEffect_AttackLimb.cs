using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_AttackLimb : BaseCompAbilityEffect
{
    private CompProperties_AbilityAttackLimb abilityProps;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        abilityProps = (CompProperties_AbilityAttackLimb)Props;

        if (target.Pawn == null || abilityProps == null)
        {
            return;
        }

        var bp = target.Pawn?.health.hediffSet.GetNotMissingParts().FirstOrDefault(x => x.def == abilityProps.limbDef);

        if (bp == null)
        {
            if (target.Pawn != null)
            {
                MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld,
                    "MePs.Failed".Translate(), 3f);
            }

            return;
        }

        target.Pawn.TakeDamage(new DamageInfo(abilityProps.damageDef, abilityProps.damage, abilityProps.armourPen, -1,
            parent.pawn, bp,
            parent.pawn.equipment.Primary.def));
        MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, abilityProps.successMessage, 3f);
    }
}