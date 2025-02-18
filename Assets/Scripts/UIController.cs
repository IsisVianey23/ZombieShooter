using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   [SerializeField]
   private GameObject _bulletsUI;
    [SerializeField]
    private Text _bulletsText;

    [SerializeField]
    private GameObject _gameOverUI;

    
    [SerializeField]
    private GameObject _youWinUI;

    private void Start()
    {
      ShowBulletsUI(false);
      ShowGameOverUI(false);  
      ShowYouWinUI(false);
    }

    public Text BulletsText
    {
        get 
        {
            return _bulletsText;
        }
    }
   public void ShowBulletsUI(bool show)
   {
     _bulletsUI.SetActive(show);
   }

   public void ShowGameOverUI(bool show)
   {
     _gameOverUI.SetActive(show);
   }

    public void ShowYouWinUI(bool show)
   {
     _youWinUI.SetActive(show);
   }

  
}
