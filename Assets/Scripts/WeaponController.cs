using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Sprite icon;
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private float damage;
    [SerializeField] private int ammo;
    [SerializeField] private float shotsPerSecond;

    public Sprite Icon { get => icon; }
    public int Ammo { get => ammo; }

    private float _nextShotTime;

    public void Shoot()
    {
        if (_nextShotTime <= Time.time)
        {
            foreach (Transform firePoint in firePoints)
            {
                BulletController bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                ammo--;
                bullet.Damage = damage;
            }
            _nextShotTime = Time.time + (1f / shotsPerSecond);
        }
    }
}
