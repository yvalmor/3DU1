using System.Collections;
using UnityEngine;

public class dummyEntity : Entity
{
    public Animator _animator;
    private static readonly int TookDamage = Animator.StringToHash("tookDamage");

    protected override IEnumerator Die()
    {
        _animator.SetBool(TookDamage, true);

        dead = true;
        
        yield break;
    }
}
