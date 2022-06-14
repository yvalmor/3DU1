namespace Entities
{
    public class EnemyEntity : Entity
    {
        protected override void Die()
        {
            gameObject.SetActive(false);
        }
    }
}