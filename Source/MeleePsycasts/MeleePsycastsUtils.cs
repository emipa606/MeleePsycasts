using Verse;

namespace MeleePsycasts;

public static class MeleePsycastsUtils
{
    public static void DamageRandomBodyPart(CompProperties_AbilityBasic props, Pawn pawn, Pawn target, int repeat = 0)
    {
        if (target == null)
        {
            return;
        }

        for (var i = 0; i < repeat; i++)
        {
            target.TakeDamage(
                new DamageInfo(
                    props.damageDef,
                    props.damage,
                    props.armourPen,
                    -1, pawn,
                    target.health.hediffSet.GetRandomNotMissingPart(props.damageDef, BodyPartHeight.Middle,
                        BodyPartDepth.Outside), pawn.equipment?.Primary?.def));
        }
    }
}