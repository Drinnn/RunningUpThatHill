using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private WeaponController[] weapons;

    public WeaponController CurrentWeapon { get => _currentWeapon; }

    private WeaponController _currentWeapon;

    private void Start()
    {
        _currentWeapon = weapons[0];
    }

    private void Update()
    {
        SwitchWeapons();
    }

    private void EquipGun(int gunIndex)
    {
        _currentWeapon = weapons[gunIndex];
    }

    private void SwitchWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipGun(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipGun(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipGun(2);
        }
    }
}
