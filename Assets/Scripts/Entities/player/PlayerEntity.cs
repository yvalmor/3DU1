using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities.player
{
    public class PlayerEntity : Entity
    {
        protected override IEnumerator Die()
        {
            SceneManager.LoadScene(0);

            return null;
        }
    }
}