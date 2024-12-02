using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_Skewer : BaseCompAbilityEffect
{
    private CompProperties_AbilitySkewer _Props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        _Props = (CompProperties_AbilitySkewer)Props;

        if (target.Pawn == null || _Props == null)
        {
            return;
        }

        var torso = target.Pawn?.health.hediffSet.GetNotMissingParts().FirstOrDefault(x => x.def == _Props.torsoDef);

        if (torso == null)
        {
            return;
        }

        target.Pawn.TakeDamage(new DamageInfo(_Props.damageDef, _Props.damage, _Props.armourPen, -1, parent.pawn, torso,
            parent.pawn.equipment.Primary.def));
        MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, "MePs.Skewer".Translate(), 6f);
    }
}