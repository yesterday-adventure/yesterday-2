using System;

public interface IDamageable
{
    public void OnDamage(Action lambda, float damage);
}