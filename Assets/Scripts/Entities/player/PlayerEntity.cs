using System.Collections;
using UnityEngine;

namespace Entities.player
{
    public class PlayerEntity : Entity
    {
        protected override IEnumerator Die()
        {
            Debug.Log("PlayerEntity is dead");
            
            // FIXME add a game over screen

            return null;
        }
    }
}