using System.Linq;
using Entities;
using UnityEngine;

public class BulletManagement : MonoBehaviour
{
    [Range(0.1f, 200f)] public float propulsion;
    public float resetDistance = 100f;
    public ObjectPool pool;
    public Transform cameraTransform;
    public Transform playerTransform;

    public BulletCounter counter;
    public ReloadInterface reloadInterface;

    public AudioSource audioSource;
    
    public int bulletFired = 0;

    private void Start()
    {
        counter.SetMaxBullet(20);
    }

    private void Fire()
    {
        if (PauseMenu.GameIsPaused)
            return;
            
        GameObject bullet = pool.GetPooledObject();

        if (bullet is null) return;

        audioSource.Play();

        
        Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
        Vector3 rotation = new Vector3(cameraRotation.x, playerTransform.rotation.eulerAngles.y, cameraRotation.z);
        
        bullet.transform.SetPositionAndRotation(cameraTransform.position, Quaternion.Euler(rotation));
        
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        
        bulletRigidbody.velocity = bullet.transform.forward * propulsion;
        bullet.SetActive(true);

        StartCoroutine(bullet.GetComponent<Bullet>().KillAfterFire(this, resetDistance));

        bulletFired++;
        counter.SetBullet(20 - bulletFired);
        
        if (bulletFired == 17)
            reloadInterface.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletFired < 20)
            Fire();
        
        if (Input.GetButtonDown("Fire2"))
            Reload();
    }

    private void Reload()
    {
        foreach (var poolObject in pool.pooledObjects.Where(poolObject =>
                     poolObject.activeSelf &&
                     Vector3.Distance(poolObject.transform.position, transform.position) >= resetDistance))
            poolObject.SetActive(false);

        bulletFired = 0;
        counter.SetBullet(20);
        
        reloadInterface.FadeOut();
    }
}