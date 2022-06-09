using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private TextMeshProUGUI cashText;

    [SerializeField] private float initialCash = 500;

    [HideInInspector] public static GameManager instance;
    public float Cash { get => _cash; set => _cash = value; }
    public bool IsPaused { get; set; }

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
        IsPaused = true;
        Time.timeScale = 0;
        shopMenu.SetActive(true);
    }

    public void CloseShop()
    {
        IsPaused = false;
        Time.timeScale = 1;
        shopMenu.SetActive(false);
    }

    public void UpdateMoneyText()
    {
        cashText.text = _cash.ToString();
    }

}
