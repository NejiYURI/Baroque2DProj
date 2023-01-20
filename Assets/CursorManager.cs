using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D Normal;
    public Texture2D Select;
    public Texture2D Hold;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(Normal,Vector2.zero,CursorMode.Auto);
        if (GameEventManager._eventManager != null)
        {
            GameEventManager._eventManager.MouseExit.AddListener(MouseUpFunc);
            GameEventManager._eventManager.MouseEnter.AddListener(MouseDownFunc);
            GameEventManager._eventManager.MouseUp.AddListener(MouseDownFunc);
            GameEventManager._eventManager.MouseDown.AddListener(MouseDragFunc);
        }
    }

    private void MouseDownFunc()
    {
        Cursor.SetCursor(Select, Vector2.zero, CursorMode.Auto);
    }

    private void MouseUpFunc()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.Auto);
    }

    private void MouseDragFunc()
    {
        Cursor.SetCursor(Hold, Vector2.zero, CursorMode.Auto);
    }
}
