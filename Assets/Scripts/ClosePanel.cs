using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour
{
     public GameObject heroPanel ;
     public GameObject mainPanel ;
    public void ClosePanelClick()
    {
         
        heroPanel.SetActive(false);
        mainPanel.SetActive(true);
        // gameObject.GetComponent<Image>().color = Color.aquamarine;
        // SceneManager.LoadScene(TargetScene);
    }
}
