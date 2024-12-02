using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_SpinCut : BaseCompAbilityEffect
{
    private CompProperties_AbilityBasic _Props;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        _Props = (CompProperties_AbilityBasic)Props;

        if (_Props == null)
        {
            return;
        }

        if (target.Cell.Impassable(parent.pawn.Map))
        {
            MoteMaker.ThrowText(parent.pawn.PositionHeld.ToVector3(), parent.pawn.MapHeld,
                "MePs.FailedSpinCut".Translate(), 3f);
            return;
        }

        parent.pawn.Position = target.Cell;

        var positionsAround = GenRadial.RadialCellsAround(target.Cell, 2, false).ToList();

        foreach (var pos in positionsAround)
        {
            var pawnList = parent.pawn.Map.mapPawns.AllPawns.ListFullCopy();

            foreach (var pawn in pawnList)
            {
                if (pawn != null && pos == pawn.Position)
                {
                    MeleePsycastsUtils.DamageRandomBodyPart(_Props, parent.pawn, pawn, 1);
                }
            }
        }

        MoteMaker.ThrowText(parent.pawn.PositionHeld.ToVector3(), parent.pawn.MapHeld, "MePs.SpinCut".Translate(), 3f);
    }
}