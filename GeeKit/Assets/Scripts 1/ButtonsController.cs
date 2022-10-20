using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject panelOfWeapon;
    [SerializeField] private Button _rollButton;
    [SerializeField] private PlayerDicerRoll _playerDiceRoll;
    private PlayerDiceController playerDiceController;

    void Start()
    {
        panelOfWeapon.SetActive(false);
        _playerDiceRoll = FindObjectOfType<PlayerDicerRoll>();
        playerDiceController = FindObjectOfType<PlayerDiceController>();
    }

    public void RollButton()
    {
        _playerDiceRoll.DiceRollButton(playerDiceController);

    }
    public void OpenWeaponPanel()
    {
        panelOfWeapon.SetActive(true);
    }
    public void CloseWeaponPanel()
    {
        panelOfWeapon.SetActive(false);
    }

    public void FightButton()
    {

       _rollButton.interactable = false;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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
