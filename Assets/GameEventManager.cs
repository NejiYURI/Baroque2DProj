using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager _eventManager;

    private void Awake()
    {
        _eventManager = this;
    }

    public UnityEvent<string> ActionTrigger;

    public UnityEvent StageClear;

    public UnityEvent<bool> HintToggle;

    public UnityEvent MouseEnter;

    public UnityEvent MouseExit;

    public UnityEvent MouseDown;

    public UnityEvent MouseUp;

    public UnityEvent MouseDrag;
}
