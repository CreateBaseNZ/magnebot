using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform label;
    private float _scaleFactor;
    private Vector3 _screenCoord;
    private Camera _cam;
    private TMP_Text _textInfo;

    private void Start()
    {
        _textInfo = label.GetComponentInChildren<TMP_Text>();
        _scaleFactor = label.GetComponentInParent<Canvas>().scaleFactor;
        _cam = Camera.main;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        print("enter");
        _screenCoord = _cam.WorldToScreenPoint(gameObject.transform.position);

        if (!label.gameObject.activeInHierarchy)
        {
            label.gameObject.SetActive(true);
        }
        
        label.anchoredPosition = new Vector2(_screenCoord.x/ _scaleFactor, _screenCoord.y/ _scaleFactor);
        var position = gameObject.transform.position;
        _textInfo.SetText("(<color=\"red\">" + position.x.ToString("0.0")
            + "</color>, <color=\"green\">" + position.z.ToString("0.0")
            + "</color>, <color=#0080FF>" + position.y.ToString("0.0") + "</color>)");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        print("exit");
        label.gameObject.SetActive(false);
    }
    
}
