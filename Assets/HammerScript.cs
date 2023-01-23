using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public string ObjId;
    public string CallId;
    public AnimationCurve WaveCurve;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.ActionTrigger.AddListener(HammerTrigger);
        }
    }

    void HammerTrigger(string objId)
    {
        if (objId.Equals(ObjId))
        {
            spriteRenderer.enabled = true;
            StartCoroutine(HammerMove());
        }
    }

    IEnumerator HammerMove()
    {
        float Timer = 0;
        while (Timer <= 0.2f)
        {
            transform.eulerAngles = new Vector3(0, 0, -1 * WaveCurve.Evaluate(Timer));
            Debug.Log(Timer);
            if (Timer >= 0.2) break;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            Timer += Time.fixedDeltaTime;
            Timer = Mathf.Clamp(Timer, -99, 0.2f);
        }

        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.ActionTrigger.Invoke(CallId);
        }
    }
}
