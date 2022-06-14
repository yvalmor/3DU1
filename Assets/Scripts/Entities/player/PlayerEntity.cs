using UnityEngine;

namespace Entities.player
{
    public class Player : Entity
    {
        protected override void Die()
        {
            Debug.Log("Player is dead");
            
            // FIXME add a game over screen
        }
    }
}