using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float MaxLife = 100f;
    public float life;

    public static int enemyCounter = 0;
    public static int spawnerCounter = 0;

    private void Start()
    {
        life = MaxLife;
    }

    public virtual void TakeDamage(float amount)
    {
        life = Mathf.Clamp(life - amount, 0, MaxLife);
        
        if (life == 0)
            StartCoroutine(Die());
    }

    protected abstract IEnumerator Die();
}