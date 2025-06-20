using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_ChargeSkewer : BaseCompAbilityEffect
{
    private CompProperties_AbilitySkewer abilityProps;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        abilityProps = (CompProperties_AbilitySkewer)Props;

        if (target.Pawn == null || abilityProps == null)
        {
            return;
        }

        var positionsAround = new List<IntVec3>
        {
            target.Pawn.Position + IntVec3.North,
            target.Pawn.Position + IntVec3.South,
            target.Pawn.Position + IntVec3.East,
            target.Pawn.Position + IntVec3.West
        };

        foreach (var pos in positionsAround)
        {
            if (pos.Impassable(target.Pawn.Map))
            {
                continue;
            }

            parent.pawn.Position = pos;

            MeleePsycastsUtils.DamageRandomBodyPart(abilityProps, parent.pawn, target.Pawn, 2);

            var torso = target.Pawn?.health.hediffSet.GetNotMissingParts()
                .FirstOrDefault(x => x.def == abilityProps.torsoDef);

            if (torso == null || target == null)
            {
                return;
            }

            target.Pawn.TakeDamage(new DamageInfo(abilityProps.damageDef, abilityProps.damage, abilityProps.armourPen,
                -1,
                parent.pawn, torso, parent.pawn.equipment.Primary.def));

            MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, "MePs.Charge".Translate(),
                3f);
            return;
        }

        MoteMaker.ThrowText(parent.pawn.PositionHeld.ToVector3(), parent.pawn.MapHeld, "MePs.FailedCharge".Translate(),
            6f);
    }
}