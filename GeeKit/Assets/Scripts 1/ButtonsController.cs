using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject panelOfWeapon;
    private PlayerDicerRoll _playerDiceRoll;
    private PlayerDiceController playerDiceController;

    void Start()
    {
        panelOfWeapon.SetActive(false);
        playerDiceController = FindObjectOfType<PlayerDiceController>();
    }

    public void OpenWeaponPanel()
    {
        panelOfWeapon.SetActive(true);
    }
    public void CloseWeaponPanel()
    {
        panelOfWeapon.SetActive(false);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerDiceRoll()
    {
        var _diceRoll = FindObjectOfType<PlayerDicerRoll>().GetComponent<PlayerDicerRoll>();
        _diceRoll.DiceRollButton();
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
