using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public string sceneToLoad;

    public void Click()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
