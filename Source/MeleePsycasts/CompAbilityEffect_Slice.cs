using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_Slice : BaseCompAbilityEffect
{
    private CompProperties_AbilityBasic _Props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        _Props = (CompProperties_AbilityBasic)Props;

        if (target.Pawn == null || _Props == null)
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

            MeleePsycastsUtils.DamageRandomBodyPart(_Props, parent.pawn, target.Pawn, 1);
            MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld,
                "MePs.PsychicSlice".Translate(), 3f);
            return;
        }

        MoteMaker.ThrowText(parent.pawn.PositionHeld.ToVector3(), parent.pawn.MapHeld,
            "MePs.FailedPsychicSlice".Translate(), 3f);
    }
}