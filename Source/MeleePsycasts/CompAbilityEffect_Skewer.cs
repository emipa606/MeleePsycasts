using System.Linq;
using RimWorld;
using Verse;

namespace MeleePsycasts;

public class CompAbilityEffect_Skewer : BaseCompAbilityEffect
{
    private CompProperties_AbilitySkewer abilityProps;

    public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
    {
        abilityProps = (CompProperties_AbilitySkewer)Props;

        if (target.Pawn == null || abilityProps == null)
        {
            return;
        }

        var torso = target.Pawn?.health.hediffSet.GetNotMissingParts()
            .FirstOrDefault(x => x.def == abilityProps.torsoDef);

        if (torso == null)
        {
            return;
        }

        target.Pawn.TakeDamage(new DamageInfo(abilityProps.damageDef, abilityProps.damage, abilityProps.armourPen, -1,
            parent.pawn, torso,
            parent.pawn.equipment.Primary.def));
        MoteMaker.ThrowText(target.Pawn.PositionHeld.ToVector3(), target.Pawn.MapHeld, "MePs.Skewer".Translate(), 6f);
    }
}