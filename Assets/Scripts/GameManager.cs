using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private TextMeshProUGUI cashText;

    [SerializeField] private float initialCash = 500;

    [HideInInspector] GameManager instance;

    private float _cash;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _cash = initialCash;
    }

    private void Update()
    {
        UpdateMoneyText();
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!shopMenu.activeSelf)
            {
                OpenShop();
            }
            else
            {
                CloseShop();
            }
        }
    }

    public void OpenShop()
    {
        Time.timeScale = 0;
        shopMenu.SetActive(true);
    }

    public void CloseShop()
    {
        Time.timeScale = 1;
        shopMenu.SetActive(false);
    }

    private void UpdateMoneyText()
    {
        cashText.text = _cash.ToString();
    }

}
