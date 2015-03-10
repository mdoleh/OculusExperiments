using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardboardButton : MonoBehaviour {
    
    public GameObject[] buttons;
    private GameObject currentSelection;

	void Update () {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100000))
        {
            if (hit.collider.transform.name.ToLower().Contains("button"))
            {
                currentSelection = hit.collider.gameObject;
                ResetBackgroundColors();
                SetColorToYellow(currentSelection);
            }
            else
            {
                ResetBackgroundColors();
            }
        }
        if (Cardboard.SDK.CardboardTriggered)
	    {
	        currentSelection.GetComponent<Button>().Click();
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
