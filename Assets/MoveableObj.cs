using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class MovePos
{
    public MovePos()
    {

    }

    public MovePos(Transform i_pos, bool i_istarget)
    {
        Pos = i_pos;
        IsTarget = i_istarget;
    }

    public Transform Pos;
    public bool IsTarget;
}

public class MoveableObj : MonoBehaviour
{
    public Transform StartPos;
    public List<MovePos> OtherPos;
    [SerializeField]
    private MovePos CurPos;

    public string TriggerObgjId;

    public bool PerfectTime;

    [SerializeField]
    private bool InRange;

    [SerializeField]
    private bool MouseInRange;

    [SerializeField]
    private Vector2 MouseOffset;

    [SerializeField]
    private bool IsClick;

    private Animator animator;

    private void Start()
    {
        CurPos = new MovePos();
        if (StartPos != null)
        {
            this.transform.position = StartPos.position;
            CurPos = new MovePos(StartPos, false);
        }
        animator = GetComponent<Animator>();
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.StageClear.AddListener(StageClear);
        }
    }

    public void SetIsPerfectTime(bool i_val)
    {
        this.PerfectTime = i_val;
    }

    private void OnMouseDrag()
    {
        if (IsClick)
        {
            this.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + MouseOffset;
        }
    }

    private void OnMouseUp()
    {
        if (InRange && PerfectTime)
        {
            this.transform.position = CurPos.Pos.position;
        }
        else
        {
            this.transform.position = StartPos.position;
            CurPos = new MovePos(StartPos, false);
        }
    }

    private void OnMouseEnter()
    {
        this.MouseInRange = true;
    }
    private void OnMouseExit()
    {
        this.MouseInRange = false;
    }

    private void OnMouseDown()
    {
        if (this.MouseInRange)
        {
            MouseOffset = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!IsClick)
            {
                animator.speed = 0;
                IsClick = true;
            }
        }
    }

    public void PlayAnimation()
    {
        animator.speed = 1;
        IsClick = false;
    }

    void StageClear()
    {
        animator.speed = 0;
    }

    public void CheckIsCorrect()
    {
        if (CurPos.IsTarget)
        {
            if (GameEventManager._eventManager != null)
            {
                GameEventManager._eventManager.ActionTrigger.Invoke(TriggerObgjId);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OtherPos.Where(x => x.Pos == collision.transform).Count() > 0)
        {
            CurPos = OtherPos.Where(x => x.Pos == collision.transform).First();
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (OtherPos.Where(x => x.Pos == collision.transform).Count() > 0)
        {
            CurPos = new MovePos();
            InRange = false;
        }
    }
}
