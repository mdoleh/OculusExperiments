using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    public string sceneToLoad;

    public void Click()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
