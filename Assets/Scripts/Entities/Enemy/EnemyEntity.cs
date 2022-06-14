using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entities.Enemy
{
    public class EnemyEntity : Entity
    {
        public Animator animator;
        public float damage;
        public Slider healthBar;

        void Update()
        {
            healthBar.value = life;
        }

        protected override void Die()
        {
            animator.SetTrigger("Die");
            Debug.Log("EnemyEntity is dead");
        }

        public override void TakeDamage(float amount)
        {
            life -= amount;

            if (life <= 0)
                Die();
            else
                animator.SetTrigger("Damage");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                other.GetComponent<Entity>().TakeDamage(damage);
        }
    }
}