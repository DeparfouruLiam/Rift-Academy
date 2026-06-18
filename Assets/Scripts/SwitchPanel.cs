using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchPanel : MonoBehaviour
{
     public GameObject openPanel ;
     public GameObject closePanel ;
    public void SwitchPanelClick()
    {
        if (openPanel != null)
        {
            openPanel.SetActive(true);
        }
        if (closePanel != null)
        {
            closePanel.SetActive(false);
        }
        // gameObject.GetComponent<Image>().color = Color.aquamarine;
        // SceneManager.LoadScene(TargetScene);
    }
}
