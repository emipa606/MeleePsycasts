namespace MeleePsycasts;

public class CompProperties_AbilityRepeatAttack : CompProperties_AbilityBasic
{
    public int repeatAmount = 2;
    public bool requiresMelee = true;

    public CompProperties_AbilityRepeatAttack()
    {
        compClass = typeof(CompAbilityEffect_RepeatAttack);
    }
}