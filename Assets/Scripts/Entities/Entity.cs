using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float MaxLife = 100f;
    public float life;
    protected bool dead = false;

    public static int enemyCounter = 0;
    protected static int spawnerCounter = 0;

    private void Start()
    {
        life = MaxLife;
    }

    public virtual void TakeDamage(float amount)
    {
        life = Mathf.Clamp(life - amount, 0, MaxLife);

        if (life > 0 || dead) return;
        
        StartCoroutine(Die());
        dead = true;
    }

    protected abstract IEnumerator Die();
}