using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float MaxLife = 100f;
    public float life;

    private void Start()
    {
        life = MaxLife;
    }

    public virtual void TakeDamage(float amount)
    {
        life = Mathf.Clamp(life - amount, 0, MaxLife);
        
        if (life == 0)
            Die();
    }

    protected abstract void Die();
}