using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameCanvasController : MonoBehaviour
{
    public AlphaMask AlphaMask;
    public AlphaMask AlphaMask_Front;
    [SerializeField] private GameOverController GameOverController;
    [SerializeField] private PlayerControlController PlayerControlController;
    void Awake()
    {
        InGameCanvasInterface.LoadController(this);
    }

    private void Start()
    {
        StartCoroutine(GameIntro());
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    //custom

    IEnumerator GameIntro()
    {
        PlayerControlController.ToggleControls(false);
        SetBackGroundFullBlur();
        yield return new WaitForSeconds(0.5f);
        ToggleBackgroundBlur(0f, 0.02f);
        yield return new WaitForSeconds(0.5f);
        PlayerControlController.ToggleControls(true);
    }
    IEnumerator GameRestart()
    {
        ToggleFrontGroundBlur(1, 0.1f);
        yield return new WaitForSeconds(0.5f);
        AsyncOperation async_load = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!async_load.isDone)
        {
            yield return null;
        }

    }

    private void SetBackGroundFullBlur()
    {
        AlphaMask.SetBackGroundFullBlur();
    }

    private void ToggleBackgroundBlur(float _blur, float _speed)
    {
        AlphaMask.ToggleBackgroundBlur(_blur, _speed);
    }

    private void ToggleFrontGroundBlur(float _blur, float _speed)
    {
        AlphaMask_Front.ToggleBackgroundBlur(_blur, _speed);
    }

    private void ShowComponents()
    {
        GameOverController.ShowTitle(0.5f);
        GameOverController.ShowBody(2f);
        GameOverController.ShowButtons(2.2f);
        PlayerControlController.ToggleControls(false);
    }


    //public methods
    public void ShowGameOverScreen()
    {
        ToggleBackgroundBlur(0.7f, 0.05f);
        ShowComponents();
    }
    public void RestartGame()
    {
        StartCoroutine(GameRestart());
    }

}
