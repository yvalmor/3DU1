using System.Collections;
using Entities.player;
using UnityEngine;
using UnityEngine.UI;

namespace Entities.Enemy
{
    public class EnemyEntity : Entity
    {
        public Animator animator;
        public Slider healthBar;
        public float damage;
        public float disappearanceRate = 1f;

        public GameObject enemyObject;

        private Collider _cl;

        private static readonly int DamageID = Animator.StringToHash("Damage");
        private static readonly int DieID = Animator.StringToHash("Die");

        void Awake()
        {
            _cl = GetComponent<Collider>();
        }

        private void Start()
        {
            life = MaxLife;
            healthBar.maxValue = MaxLife;
        }

        void Update()
        {
            healthBar.value = life;
        }

        protected override IEnumerator Die()
        {
            animator.SetTrigger(DieID);

            _cl.enabled = false;
            healthBar.gameObject.SetActive(false);

            yield return new WaitForSeconds(2);

            Vector3 baseScale = enemyObject.transform.localScale;
            Vector3 targetScale = Vector3.zero;

            while (enemyObject.transform.localScale.x > 0.01)
            {
                enemyObject.transform.localScale =
                    Vector3.Lerp(enemyObject.transform.localScale, targetScale, disappearanceRate * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            
            healthBar.gameObject.SetActive(true);
            enemyObject.gameObject.SetActive(false);
            enemyObject.transform.localScale = baseScale;

            animator.SetTrigger("Idle");
        }

        public override void TakeDamage(float amount)
        {
            life -= amount;

            if (life <= 0)
                StartCoroutine(Die());
            else
                animator.SetTrigger(DamageID);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                other.GetComponent<PlayerEntity>().TakeDamage(damage);
        }

        public void Reset()
        {
            _cl.enabled = true;
            
            life = MaxLife;
        }
    }
}