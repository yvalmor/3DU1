using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Entities
{
    public class SpawnerEntity : Entity
    {
        public Slider healthBar;
        public GameObject spawnerObject;

        protected override IEnumerator Die()
        {
            Spawner.ReduceDelay();
            
            Destroy(spawnerObject);

            return null;
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
    }
}