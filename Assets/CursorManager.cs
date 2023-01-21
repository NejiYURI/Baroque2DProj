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
        Cursor.SetCursor(Select, new Vector2(25,25), CursorMode.ForceSoftware);
    }

    private void MouseUpFunc()
    {
        Cursor.SetCursor(Normal, new Vector2(10, 10), CursorMode.ForceSoftware);
    }

    private void MouseDragFunc()
    {
        Cursor.SetCursor(Hold, new Vector2(25, 25), CursorMode.ForceSoftware);
    }
}
