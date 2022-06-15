using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities.player
{
    public class PlayerEntity : Entity
    {
        protected override IEnumerator Die()
        {
            SceneManager.LoadScene(3);

            Cursor.lockState = CursorLockMode.None;
            
            yield break;
        }
    }
}