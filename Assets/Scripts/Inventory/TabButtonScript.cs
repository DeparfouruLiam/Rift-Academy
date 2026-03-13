using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TabButtonScript : MonoBehaviour
{
   public GameObject[] Panels;

    public void OpenTab(GameObject panelToOpen)
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(false);
        }

        panelToOpen.SetActive(true);
    }
    
}
