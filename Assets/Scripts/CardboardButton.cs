using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardboardButton : MonoBehaviour {
    
    public GameObject[] buttons;

	void Update () {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.transform.name.ToLower().Contains("button"))
            {
                SetColorToYellow(hit.collider.gameObject);
            }
            else
            {
                ResetBackgroundColors();
            }
        }
	}

    private void ResetBackgroundColors()
    {
        foreach (var button in buttons)
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }

    private void SetColorToYellow(GameObject button)
    {
        button.GetComponent<Image>().color = Color.yellow;
    }
}
