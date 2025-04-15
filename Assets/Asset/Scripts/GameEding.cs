using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEding : MonoBehaviour
{
    public float fadeDuration = 1f;//thời gian mở sáng
    public float timerExit = 1f;
    public CanvasGroup CanvasExit;
    public CanvasGroup CanvasCaught;
    public Button button1, button2;
    bool IsExit = false;
    public bool isCought = false;
    float timer = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsExit = true;
        }
    }

    void Update()
    {
        Debug.Log("isCought: " + isCought);
        if (IsExit)
        {
            EndLevel(CanvasExit);
        }
        else if (isCought)
        {
            EndLevel(CanvasCaught);
        }

    }


    void EndLevel(CanvasGroup Type)
    {
        timer += Time.deltaTime;

        Type.alpha = timer / fadeDuration;
        StartCoroutine(EndGame());

    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(timerExit);
        Application.Quit();
        // UnityEditor.EditorApplication.isPlaying = false;
    }


    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

}
