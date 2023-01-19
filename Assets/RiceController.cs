using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceController : MonoBehaviour
{
    public string ObjId;
    public Color ChangeColor;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private bool IsTrig;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.ActionTrigger.AddListener(changeSprite);
            GameEventManager._eventManager.ActionTrigger.AddListener(SetEnabled);
        }
    }

    void changeSprite(string _objID)
    {
        if (spriteRenderer != null && this.ObjId.Equals(_objID))
        {
            spriteRenderer.color = ChangeColor;
            IsTrig = true;
        }
    }

    void SetEnabled(string _objID)
    {
        if (spriteRenderer != null && _objID.Equals("Complete"))
        {
            spriteRenderer.enabled = false;
        }
    }

    public bool IsTriggered()
    {
        return IsTrig;
    }
}
