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
        _textInfo = label.GetComponent<TMP_Text>();
    }

    private void OnMouseOver()
    {
        _screenCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        if (!label.gameObject.activeInHierarchy)
        {
            label.gameObject.SetActive(true);
        }
        label.anchoredPosition = (new Vector2(Screen.width, Screen.height) / _referenceSize) * _screenCoord;
        _textInfo.text = gameObject.transform.position.ToString();
    }

    private void OnMouseExit()
    {
        label.gameObject.SetActive(false);
    }
}
