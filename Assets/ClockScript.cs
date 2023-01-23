using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{

    public Animator animator;

    private Rigidbody2D rg;

    public string ClockStopId;

    public string ClockCrashedId;

    public string ClockFlyId;

    // Start is called before the first frame update
    void Start()
    {
        rg= GetComponent<Rigidbody2D>();
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.ActionTrigger.AddListener(ClockStop);
            GameEventManager._eventManager.ActionTrigger.AddListener(ClockFly);
            GameEventManager._eventManager.ActionTrigger.AddListener(ClockCrash);
        }
    }
    void ClockStop(string objId)
    {
        if (objId.Equals(ClockStopId))
        {
            animator.SetTrigger("ClockStop");
            StartCoroutine(countDownTimer());
        }
    }

    void ClockFly(string objId)
    {
        if (objId.Equals(ClockFlyId))
        {
            rg.gravityScale = 1;
            animator.SetTrigger("ClockStop");
            rg.AddForce(new Vector2(1000f, 500f));
            rg.AddTorque(100);
            StartCoroutine(countDownTimer());
        }
    }

    void ClockCrash(string objId)
    {
        if (objId.Equals(ClockCrashedId))
        {
            animator.SetTrigger("ClockStop");
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
