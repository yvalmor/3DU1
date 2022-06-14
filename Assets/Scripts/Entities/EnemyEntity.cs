namespace Entities
{
    public class Enemy : Entity
    {
        protected override void Die()
        {
            gameObject.SetActive(false);
        }
    }
}