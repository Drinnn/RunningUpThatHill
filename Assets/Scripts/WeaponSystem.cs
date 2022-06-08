using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private WeaponController[] weapons;
    [SerializeField] private Image weaponIconContainer;
    [SerializeField] private TextMeshProUGUI ammoText;

    public WeaponController CurrentWeapon { get => _currentWeapon; }

    private WeaponController _currentWeapon;

    private void Start()
    {
        EquipGun(0);
    }

    private void Update()
    {
        SwitchWeapons();
        RenderAmmoToUI();
    }

    private void EquipGun(int gunIndex)
    {
        _currentWeapon = weapons[gunIndex];
        ChangeWeaponIcon();
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

    private void ChangeWeaponIcon()
    {
        weaponIconContainer.sprite = _currentWeapon.Icon;
    }

    private void RenderAmmoToUI()
    {
        ammoText.text = _currentWeapon.Ammo.ToString();
    }
}
