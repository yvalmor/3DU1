using UnityEngine;

namespace Entities.player
{
    public class PlayerEntity : Entity
    {
        protected override void Die()
        {
            Debug.Log("PlayerEntity is dead");
            
            // FIXME add a game over screen
        }
    }
}