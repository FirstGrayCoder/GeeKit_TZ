using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemyObject: MonoBehaviour
{
    public static int enemyDemage = 5;
    private int _enemyHPMax = 100;
    private int _enemyHP = 100;
    
    private int armorMax = 100;
    private int armor = 100;

    [SerializeField] private int _numOfLevels = 12;
    [SerializeField] private GameObject _winPanel;

    [Header("UI")]
    public TMP_Text _hpText;
    public TMP_Text _armorText;
    public TMP_Text _levelText;
    public Slider sliderHP;
    public Slider sliderArmor;

   

    public void Start()
    {
        sliderHP.maxValue = _enemyHPMax;
        sliderHP.value = _enemyHP;
        sliderArmor.maxValue = armorMax;
        sliderArmor.value = armor;
    }
    public void DemageFromPlayer(int demage)
    {
        if (sliderArmor.value > 0) sliderArmor.value -= demage;
        else sliderHP.value -= demage;
    }

    public void Update()
    {
        if (sliderHP.value <= 0)
        {
            _winPanel.SetActive(true);
            _levelText.text = "level " + SceneManager.GetActiveScene().buildIndex.ToString() + "/" + _numOfLevels;
        }
        
        _hpText.text = sliderHP.value.ToString() + "/" + _enemyHPMax.ToString();
        _armorText.text = sliderArmor.value.ToString() + "/" + armorMax.ToString();
    }
}
