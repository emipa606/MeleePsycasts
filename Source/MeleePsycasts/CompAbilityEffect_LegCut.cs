using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_LegCut : BaseCompAbilityEffect
{
    private CompProperties_AbilityLegCut _Props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        _Props = (CompProperties_AbilityLegCut)Props;

        if (target.Pawn == null || _Props == null)
        {
            return;
        }

        var bps = target.Pawn.health.hediffSet.GetNotMissingParts().ToList();
        var leg = bps.FirstOrDefault(x => x.def == _Props.legDef);

        target.Pawn.TakeDamage(new DamageInfo(_Props.damageDef, _Props.damage, _Props.armourPen, -1, parent.pawn, leg,
            parent.pawn.equipment.Primary.def));

        bps = target.Pawn.health.hediffSet.GetNotMissingParts(BodyPartHeight.Bottom, BodyPartDepth.Outside).ToList();
        leg = bps.FirstOrDefault(x => x.def == _Props.legDef);

        if (leg.def.defName != _Props.legDef.defName)
        {
            bps = target.Pawn.health.hediffSet.GetNotMissingParts(BodyPartHeight.Bottom, BodyPartDepth.Outside)
                .ToList();
            leg = bps.FirstOrDefault(x => x.def == _Props.legDef);

            target.Pawn.TakeDamage(new DamageInfo(_Props.damageDef, _Props.damage, _Props.armourPen, -1, parent.pawn,
                leg, parent.pawn.equipment.Primary.def));
        }

        target.Pawn.TakeDamage(new DamageInfo(_Props.damageDef, _Props.damage, _Props.armourPen, -1, parent.pawn, leg,
            parent.pawn.equipment.Primary.def));

        MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, "MePs.LegCut".Translate(),
            3f);
    }
}