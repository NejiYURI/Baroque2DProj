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
}
