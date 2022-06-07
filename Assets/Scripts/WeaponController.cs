using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float damage;
    [SerializeField] private float shotsPerSecond;

    private float _nextShotTime;

    public void Shoot()
    {
        if (_nextShotTime <= Time.time)
        {
            BulletController bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.Damage = damage;
            _nextShotTime = Time.time + (1f / shotsPerSecond);
        }
    }
}
