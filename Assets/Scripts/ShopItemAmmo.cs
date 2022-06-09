using UnityEngine;
using TMPro;

public class ShopItemAmmo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private WeaponController weapon;
    [SerializeField] private float cost;
    [SerializeField] private int ammoAmount;

    private void Update()
    {
        priceText.text = cost.ToString();
    }

    public void BuyAmmo()
    {
        if (GameManager.instance.Cash >= cost)
        {
            GameManager.instance.Cash -= cost;
            weapon.AddAmmo(ammoAmount);
            GameManager.instance.UpdateMoneyText();
        }
    }

}
