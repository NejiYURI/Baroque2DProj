using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObj : MonoBehaviour
{
    public Transform StartPos;
    public Transform OtherPos;

    public bool PerfectTime;

    [SerializeField]
    private bool InRange;

    [SerializeField]
    private bool MouseInRange;

    [SerializeField]
    private bool IsClick;

    private Animator animator;

    private void Start()
    {
        if (StartPos != null)
        {
            this.transform.position = StartPos.position;
        }
        animator = GetComponent<Animator>();
    }

    public void SetIsPerfectTime(bool i_val)
    {
        this.PerfectTime = i_val;
    }

    private void OnMouseDrag()
    {
        if (IsClick)
        {
            this.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (InRange && PerfectTime)
        {
            this.transform.position = OtherPos.position;
        }
        else
        {
            this.transform.position = StartPos.position;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == OtherPos)
        {
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == OtherPos)
        {
            InRange = false;
        }
    }
}
