using RimWorld;
using Verse;

namespace MeleePsycasts;

public class BaseCompAbilityEffect : CompAbilityEffect
{
    public override bool GizmoDisabled(out string reason)
    {
        if (parent.pawn.equipment.Primary == null || !parent.pawn.equipment.Primary.def.IsMeleeWeapon)
        {
            reason = "MePs.RequiresMelee".Translate();
            return true;
        }

        reason = "MePs.HasMelee".Translate();
        return false;
    }

    public override bool AICanTargetNow(LocalTargetInfo target)
    {
        return true;
    }
}