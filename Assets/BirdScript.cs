using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public string ObjId;
    private Animator animator;
    public RiceController riceController;
    public GameObject RiceObj;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        RiceObj.SetActive(false);
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.ActionTrigger.AddListener(BirdMove);
        }
    }

    void BirdMove(string i_ObjId)
    {
        if (animator != null && riceController!=null && this.ObjId.Equals(i_ObjId))
        {
            if (riceController.IsTriggered())
            {
                RiceObj.SetActive(true);
                GameEventManager._eventManager.ActionTrigger.Invoke("Complete");
                animator.SetTrigger("Move");
                StartCoroutine(countDownTimer());
            }
            
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
