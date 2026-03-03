using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigateTo : MonoBehaviour
{
    [SerializeField] string aled;
    
    public void NavigateClick()
    {
        gameObject.GetComponent<Image>().color = Color.aquamarine;
        SceneManager.LoadScene(aled);
    }
}
