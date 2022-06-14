namespace Entities
{
    public class SpawnerEntity : Entity
    {
        protected override void Die()
        {
            Spawner.ReduceDelay();
            
            Destroy(gameObject);
        }
    }
}