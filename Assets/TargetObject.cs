using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public string ObjId;

    public Sprite SuccessSprite;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.ActionTrigger.AddListener(changeSprite);
        }
    }

    void changeSprite(string _objID)
    {
        if (spriteRenderer != null && this.ObjId.Equals(_objID))
        {
            spriteRenderer.sprite = SuccessSprite;
            StartCoroutine(countDownTimer());
        }
    }

    IEnumerator countDownTimer()
    {
        yield return new WaitForSeconds(2);
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.StageClear.Invoke();
        }
    }
}
