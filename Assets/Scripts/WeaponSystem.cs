using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private WeaponController[] weapons;
    [SerializeField] private Image weaponIconContainer;
    [SerializeField] private TextMeshProUGUI ammoText;

    public WeaponController CurrentWeapon { get => _currentWeapon; }

    private WeaponController _currentWeapon;
    private bool _pistolMode;
    private bool _shotgunMode;
    private bool _rifleMode;

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
        SetMode(gunIndex);
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

    private void SetMode(int gunIndex)
    {
        ResetModes();
        ResetAnimator();
        if (gunIndex == 0)
        {
            _pistolMode = true;
            playerAnimator.SetBool("PistolMode", true);
        }
        else if (gunIndex == 1)
        {
            _shotgunMode = true;
            playerAnimator.SetBool("ShotgunMode", true);
        }
        else if (gunIndex == 2)
        {
            _rifleMode = true;
            playerAnimator.SetBool("RifleMode", true);
        }
    }

    private void ResetModes()
    {
        _pistolMode = false;
        _shotgunMode = false;
        _rifleMode = false;
    }

    private void ResetAnimator()
    {
        playerAnimator.SetBool("PistolMode", false);
        playerAnimator.SetBool("ShotgunMode", false);
        playerAnimator.SetBool("RifleMode", false);
    }
}
