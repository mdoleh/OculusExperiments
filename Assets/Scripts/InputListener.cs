using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class InputListener : MonoBehaviour
{
    public GameObject[] buttons;
    private int currentIndex;

    void Awake()
    {
        currentIndex = 0;
        SetColorToYellow(buttons[currentIndex]);
    }

	void Update ()
	{
	    if (Input.GetKeyUp(KeyCode.DownArrow))
	    {
	        ++currentIndex;
	        if (currentIndex > buttons.Length - 1) currentIndex = 0;
            UpdateSelection(currentIndex);
	    }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
	    {
            --currentIndex;
            if (currentIndex < 0) currentIndex = buttons.Length - 1;
            UpdateSelection(currentIndex);
	    }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            buttons[currentIndex].GetComponent<Button>().Click();
        }
	}

    private void UpdateSelection(int index)
    {
        ResetBackgroundColors();
        SetColorToYellow(buttons[index]);
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
