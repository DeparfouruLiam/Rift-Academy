using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField] string TargetScene;
    
    public void NavigateClick()
    {
        gameObject.GetComponent<Image>().color = Color.aquamarine;
        SceneManager.LoadScene(TargetScene);
    }
}
