using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.HintToggle.AddListener(ToggleHint);
        }
    }

    void ToggleHint(bool SetShow)
    {
        spriteRenderer.enabled= SetShow;
    }
}
