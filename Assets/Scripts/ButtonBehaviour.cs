using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    //if you want it private do:
    [SerializeField] private Texture2D _cursor;
    private CursorMode _cursorMode;

    private void Start()
    {
#if UNITY_WEBGL
        _cursorMode = CursorMode.ForceSoftware;
#else
        _cursorMode = CursorMode.Auto;
#endif
    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(_cursor, new Vector2(5, 0), _cursorMode);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, _cursorMode);
    }

}