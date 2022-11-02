using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerObject: MonoBehaviour 
{
    public static int _demageFromEnemy = 10;
    private int _playerHPMax = 100;
    private int _playerArmorMax = 100;
    private int _playerHP = 100;
    private int _playerArmor = 100;
    [SerializeField] private bool isProtected;

    [Header("UI")]
    public Slider sliderHP;
    public Slider sliderArmor;
    public TMP_Text _hpText;
    public TMP_Text _armorText;
    [SerializeField] private GameObject _losePanel;
 
    public void Start()
    {
        _losePanel.SetActive(false);
        sliderHP.maxValue = _playerHPMax;
        sliderHP.value = _playerHP;
        sliderArmor.maxValue = _playerArmorMax;
        sliderArmor.value = _playerArmor;
    }

    public void DemageFromEnemy()
    {
        if (sliderArmor.value > 0) sliderArmor.value -= _demageFromEnemy;
        else sliderHP.value -= _demageFromEnemy;
    }

    public void GetHealth(int health)
    {
        sliderHP.value += health;
        if (sliderArmor.value > 100) sliderArmor.value = 100;
    }

    public void AtackOnArmor()
    {
        if (sliderArmor.value > 0) sliderArmor.value -= _demageFromEnemy;
        else DemageFromEnemy();
    }

    public void Update()
    {
        if (sliderHP.value <=0 ) _losePanel.SetActive(true);
        _hpText.text = sliderHP.value.ToString() + "/" + sliderHP.maxValue.ToString();
        _armorText.text = sliderArmor.value.ToString() + "/" + sliderArmor.maxValue.ToString();
    }
}
