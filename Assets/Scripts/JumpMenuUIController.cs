using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpMenuUIController : MonoBehaviour
{
    public List<GameObject> menuPanels;
    private int activePanel = 0;

    // Start is called before the first frame update
    void Start()
    {
        menuPanels.ForEach(f => f.SetActive(false));
        menuPanels[activePanel].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
