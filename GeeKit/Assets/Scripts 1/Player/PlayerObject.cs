using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerObject: MonoBehaviour 
{
    public static int _demage = 25;
    private int _playerHP = 100;
    private int _playerArmor = 100;
    public Slider sliderHP;
    public Slider sliderArmor;
    [SerializeField] private bool isProtected;
    public TMP_Text _hpText;
    public TMP_Text _armorText;
    [SerializeField] private GameObject _losePanel;
 
    public void Start()
    {
        _losePanel.SetActive(false);
        //sliderHP.value = _playerHP;
        sliderArmor.value = _playerArmor;
    }

    public void DemageFromEnemy()
    {
        if (sliderArmor.value > 0) AtackOnArmor();
        else sliderHP.value -= EnemyObject.demage;

    }

    public void GetHealth()
    {
        sliderHP.value += 10;
        if (sliderArmor.value > 100) sliderArmor.value = 100;
    }
    public void AtackOnArmor()
    {
        if (sliderArmor.value > 0) sliderArmor.value -= EnemyObject.demage;
        else DemageFromEnemy();

    }

    public void FixedUpdate()
    {
        if (sliderHP.value <=0 ) _losePanel.SetActive(true);
        _hpText.text = sliderHP.value.ToString() + "/" + sliderHP.maxValue.ToString();
        _armorText.text = sliderArmor.value.ToString() + "/" + sliderArmor.maxValue.ToString();
    }


}
