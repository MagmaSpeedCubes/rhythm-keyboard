using UnityEngine;
using UnityEngine.UI;
public class DisableOnStart : MonoBehaviour
{

    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
}
