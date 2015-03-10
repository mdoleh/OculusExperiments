using UnityEngine;
using System.Collections;

public class ExitListener : MonoBehaviour {

	void Update () {
	    if (Input.GetKey(KeyCode.LeftControl))
	    {
	        Application.LoadLevel("Menu");
	    }
	}
}
