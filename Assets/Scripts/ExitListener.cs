using UnityEngine;
using System.Collections;

public class ExitListener : MonoBehaviour {

	void Update () {
	    if (Input.GetKeyUp(KeyCode.Escape))
	    {
	        Application.LoadLevel("Menu");
	    }
	}
}
