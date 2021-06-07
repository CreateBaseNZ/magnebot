using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverInfo : MonoBehaviour
{
    public RectTransform label;
    private Vector2 _referenceSize = new Vector2(1920, 1080);
    private Vector3 _screenCoord;

    private TMP_Text _textInfo;

    private void Start()
    {
        _textInfo = label.GetComponentInChildren<TMP_Text>();
    }

    private void OnMouseOver()
    {
        _screenCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        if (!label.gameObject.activeInHierarchy)
        {
            label.gameObject.SetActive(true);
        }
        label.anchoredPosition = _screenCoord;
        var position = gameObject.transform.position;
        _textInfo.SetText("(<color=\"red\">" + position.x.ToString("0.0")
            + "</color>, <color=\"green\">" + position.z.ToString("0.0")
            + "</color>, <color=#0080FF>" + position.y.ToString("0.0") + "</color>)");
    }

    private void OnMouseExit()
    {
        label.gameObject.SetActive(false);
    }
}
