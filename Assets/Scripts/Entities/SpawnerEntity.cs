using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Entities
{
    public class SpawnerEntity : Entity
    {
        public Slider healthBar;
        public GameObject spawnerObject;
        public GameObject spawnerEmission;
        public GameObject spawnerParticles;
        public Light spawnerLight;

        public float disappearanceRate = 1f;

        private Collider _cl;
        
        protected override IEnumerator Die()
        {
            _cl.enabled = false;
            
            Spawner.ReduceDelay();
            
            spawnerObject.GetComponent<Spawner>().Deactivate();

            Vector3 currentScale = Vector3.one;
            Vector3 targetScale = Vector3.zero;

            while (currentScale.x > 0.01)
            {
                currentScale = Vector3.Lerp(currentScale, targetScale, disappearanceRate * Time.deltaTime);

                spawnerObject.transform.localScale = currentScale;
                spawnerEmission.transform.localScale = currentScale;
                spawnerParticles.transform.localScale = currentScale;

                spawnerLight.intensity = Mathf.Lerp(spawnerLight.intensity, 0, disappearanceRate * Time.deltaTime);
                
                yield return new WaitForEndOfFrame();
            }

            spawnerCounter--;

            if (spawnerCounter == 0 && enemyCounter == 0)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(0);
            }
            
            Destroy(spawnerObject);
        }

        private void Start()
        {
            spawnerCounter++;
            
            life = MaxLife;
            healthBar.maxValue = MaxLife;
            _cl = GetComponent<Collider>();
        }

        void Update()
        {
            healthBar.value = life;
        }
    }
}