using System.Collections;
using UnityEngine;

namespace Entities
{
    public class Bullet : MonoBehaviour
    {
        public IEnumerator KillAfterFire(BulletManagement bm, float distance)
        {
            yield return new WaitUntil(() => Vector3.Distance(transform.position, bm.transform.position) > distance);

            gameObject.SetActive(false);
        }
    }
}