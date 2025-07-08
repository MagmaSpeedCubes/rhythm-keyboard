using UnityEngine;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    [SerializeField] private Canvas startCanvas;
    [SerializeField] private Canvas openCanvas;

    public void onClick(){
        startCanvas.enabled = false;
        openCanvas.enabled = true;
    }
}
