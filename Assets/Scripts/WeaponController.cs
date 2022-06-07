using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private float damage;
    [SerializeField] private int ammo;
    [SerializeField] private float shotsPerSecond;

    private float _nextShotTime;

    public void Shoot()
    {
        if (_nextShotTime <= Time.time)
        {
            foreach (Transform firePoint in firePoints)
            {
                BulletController bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.Damage = damage;
            }
            ammo--;
            _nextShotTime = Time.time + (1f / shotsPerSecond);
        }
    }
}
