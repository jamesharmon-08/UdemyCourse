using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    // Start is called before the first frame update

    public int currentCoins;

     private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();

        }
    }

    public void GetCoins(int coinToAdd)
    {
        currentCoins += coinToAdd;
        UIManager.instance.UpdateCoins();
    }

    public void Quit() {
    #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
    #endif
    #if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
    #elif (UNITY_STANDALONE) 
        Application.Quit();
    #elif (UNITY_WEBGL)
        Application.OpenURL("about:blank");
    #endif
  }

  public void PauseUnpause()
  {
      if(!UIManager.instance.pauseScreen.activeInHierarchy)
      {
          UIManager.instance.pauseScreen.SetActive(true);
          Time.timeScale = 0f; 
          PlayerController.instance.canMove = false; 
      } 
      else
      {
          UIManager.instance.pauseScreen.SetActive(false);
          Time.timeScale = 1f; 
          PlayerController.instance.canMove = true;
      }
  }
}
