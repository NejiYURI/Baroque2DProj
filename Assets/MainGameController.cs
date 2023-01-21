using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    public GameObject StageClearPanel;
    [SerializeField]
    private bool ShowHint;
    private void Start()
    {
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.StageClear.AddListener(StageClear);
        }
        if (StageClearPanel != null)
        {
            StageClearPanel.transform.LeanScale(Vector3.zero, 0);
        }
    }

    void StageClear()
    {
        if (StageClearPanel != null)
        {
            StageClearPanel.transform.LeanScale(Vector3.one, 0.2f);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 2);
    }

    public void ToggleHint()
    {
        if (GameEventManager._eventManager != null)
        {
            ShowHint = !ShowHint;
            GameEventManager._eventManager.HintToggle.Invoke(ShowHint);
        }
    }
}
