using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject bossInfo;

    public Slider healthSlider;
    public Slider staminaSlider;
    public TMP_Text healthText;
    public TMP_Text staminaText;
    public TMP_Text coinsText;

    public Slider bossHealth;
    public TMP_Text bossNameText;

    public string mainMenuScene;

    public GameObject pauseScreen;
    public GameObject blackoutScreen;

    private void Awake()
    {
        instance = this;  
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        UpdateStamina();
        UpdateCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        healthSlider.maxValue = PlayerHealthController.instance.maxHealth;
        healthSlider.value = PlayerHealthController.instance.currentHealth;

        healthText.text = "HEALTH "+PlayerHealthController.instance.currentHealth+"/"+PlayerHealthController.instance.maxHealth;
        
    }

       public void UpdateStamina()
    {
        staminaSlider.maxValue = PlayerController.instance.totalStamina;
        staminaSlider.value = PlayerController.instance.currentStamina;

        staminaText.text = "STAMINA "+Mathf.RoundToInt(PlayerController.instance.currentStamina)+"/"+PlayerController.instance.totalStamina;
        
    }

    public void UpdateBossHealth(int current, int total)
    {
        bossHealth.maxValue = total;
        bossHealth.value = current;
    }

    public void UpdateCoins()
    {
        coinsText.text = "Coins: "+GameManager.instance.currentCoins;
        
    }
    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }

    public void ActivateBoss(string bossName)
    {
        bossNameText.text=bossName;
        bossInfo.SetActive(true);

    }

    public void QuitGame()
    {
        GameManager.instance.Quit();
    }
}
