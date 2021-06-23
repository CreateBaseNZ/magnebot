using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHelper : MonoBehaviour
{
    public float speed = 0;
    float pos = 0;
    private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        pos += speed * Time.timeScale;

        if (pos > 1.0F)
        {
            pos -= 1.0F;
        }
        if(GameController.Instance.gameState != GameController.GameState.PLAY)
        {
            speed /= (1+Time.deltaTime);
        }

        image.uvRect = new Rect(pos, 0, 1, 1);
    }
}
