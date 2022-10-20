using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnemyObject: MonoBehaviour
{
    public static int demage = 5;
    private int _enemyHP = 100;
    public Slider sliderHP;
    public Slider sliderArmor;
    public static int armor = 0;
    public TMP_Text _hpText;
    public TMP_Text _armorText;
    public TMP_Text _levelText;
    [SerializeField] private int _numOfLevels = 12;
    [SerializeField] private GameObject _winPanel;

    public void Start()
    {
        sliderHP.value = _enemyHP;
    }
    public void DemageFromPlayer()
    {
        if (sliderHP.value > 0)
        {
            if (armor > 0)
                armor -= PlayerObject._demage;
            else
                sliderHP.value -= PlayerObject._demage;
        }
    }

    public void FixedUpdate()
    {
        if (sliderHP.value <= 0)
        {
            _winPanel.SetActive(true);
            _levelText.text = "level " + SceneManager.GetActiveScene().buildIndex.ToString() + "/" + _numOfLevels;
        }
        
        _hpText.text = sliderHP.value.ToString() + "/" + sliderHP.maxValue.ToString();
        _armorText.text = sliderArmor.value.ToString() + "/" + sliderArmor.maxValue.ToString();
    }



}
