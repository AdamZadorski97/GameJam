using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class LevelManager : MonoSingleton<LevelManager>
{
    public static LevelManager _Instance { get; private set; }
    [SerializeField] private CanvasGroup gameOverScreen;



    public void TurnOnGameOverScreen()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.DOFade(1, 0.5f);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
