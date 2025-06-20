using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_LegCut : BaseCompAbilityEffect
{
    private CompProperties_AbilityLegCut abilityProps;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        abilityProps = (CompProperties_AbilityLegCut)Props;

        if (target.Pawn == null || abilityProps == null)
        {
            return;
        }

        var bps = target.Pawn.health.hediffSet.GetNotMissingParts().ToList();
        var leg = bps.FirstOrDefault(x => x.def == abilityProps.legDef);

        target.Pawn.TakeDamage(new DamageInfo(abilityProps.damageDef, abilityProps.damage, abilityProps.armourPen, -1,
            parent.pawn, leg,
            parent.pawn.equipment.Primary.def));

        bps = target.Pawn.health.hediffSet.GetNotMissingParts(BodyPartHeight.Bottom, BodyPartDepth.Outside).ToList();
        leg = bps.FirstOrDefault(x => x.def == abilityProps.legDef);

        if (leg.def.defName != abilityProps.legDef.defName)
        {
            bps = target.Pawn.health.hediffSet.GetNotMissingParts(BodyPartHeight.Bottom, BodyPartDepth.Outside)
                .ToList();
            leg = bps.FirstOrDefault(x => x.def == abilityProps.legDef);

            target.Pawn.TakeDamage(new DamageInfo(abilityProps.damageDef, abilityProps.damage, abilityProps.armourPen,
                -1, parent.pawn,
                leg, parent.pawn.equipment.Primary.def));
        }

        target.Pawn.TakeDamage(new DamageInfo(abilityProps.damageDef, abilityProps.damage, abilityProps.armourPen, -1,
            parent.pawn, leg,
            parent.pawn.equipment.Primary.def));

        MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, "MePs.LegCut".Translate(),
            3f);
    }
}