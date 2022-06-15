using System.Collections;
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

            Vector3 baseScale = transform.localScale;
            Vector3 targetScale = Vector3.zero;

            while (transform.localScale.x > 0.01)
            {
                transform.localScale =
                    Vector3.Lerp(transform.localScale, targetScale, disappearanceRate * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            
            healthBar.gameObject.SetActive(true);
            gameObject.SetActive(false);
            transform.localScale = baseScale;

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
                other.GetComponent<Entity>().TakeDamage(damage);
        }

        public void Reset()
        {
            _cl.enabled = true;
            
            life = MaxLife;
        }
    }
}