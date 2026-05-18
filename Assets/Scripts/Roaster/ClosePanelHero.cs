using UnityEngine;

public class ClosePanelHero : MonoBehaviour
{
    public GameObject heroPanel;
    public GameObject mainPanel;

    public void ClosePanelHeroClick()
    {
        heroPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
     
}
