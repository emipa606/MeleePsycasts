using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_AttackLimb : BaseCompAbilityEffect
{
    private CompProperties_AbilityAttackLimb _Props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        _Props = (CompProperties_AbilityAttackLimb)Props;

        if (target.Pawn == null || _Props == null)
        {
            return;
        }

        var bp = target.Pawn?.health.hediffSet.GetNotMissingParts().FirstOrDefault(x => x.def == _Props.limbDef);

        if (bp == null)
        {
            if (target.Pawn != null)
            {
                MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld,
                    "MePs.Failed".Translate(), 3f);
            }

            return;
        }

        target.Pawn.TakeDamage(new DamageInfo(_Props.damageDef, _Props.damage, _Props.armourPen, -1, parent.pawn, bp,
            parent.pawn.equipment.Primary.def));
        MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, _Props.successMessage, 3f);
    }
}