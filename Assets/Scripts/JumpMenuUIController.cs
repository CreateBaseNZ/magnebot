using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class JumpMenuUIController : MonoBehaviour
{
    public List<GameObject> menuPanels;
    public List<Toggle> modifiers;
    public TMP_Text scoreMultiplier;
    private int activePanel = 0;

    // Start is called before the first frame update
    void Start()
    {
        menuPanels.ForEach(f => f.SetActive(false));
        menuPanels[activePanel].SetActive(true);
        SetScoreMultiplier();

        foreach (var item in modifiers)
        {
            item.isOn = PlayerPrefs.GetInt(item.name) == 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetModifier(Toggle toggle)
    {
        PlayerPrefs.SetInt(toggle.name, (toggle.isOn ? 1 : 0));
        SetScoreMultiplier();
    }

    private void SetScoreMultiplier()
    {
        float multiplier = 1
            + PlayerPrefs.GetInt("Acceleration") * 0.8f
            + PlayerPrefs.GetInt("Flying", 0) * 0.5f
            + PlayerPrefs.GetInt("Large", 0) * 0.25f;

        PlayerPrefs.SetFloat("scoreMultiplier", multiplier);
        scoreMultiplier.text = "<color=grey>Total Multiplier </color><b><size=32>" + multiplier.ToString("0.00") + "x";
    }

    public void PlayButton()
    {
        SceneController.Instance.LoadScene("Project_Jump_1");
    }

    public void EnableMenuPanel(int id)
    {
        menuPanels[activePanel].SetActive(false);
        menuPanels[id].SetActive(true);
        activePanel = id;
    }
}
