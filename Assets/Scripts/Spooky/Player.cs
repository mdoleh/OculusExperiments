using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Transform[] angels;
    private int counter = 0;

    void Awake()
    {
        
    }

	void Update () {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
	    if (Physics.Raycast(ray, out hit, 100000))
	    {
	        if (hit.collider.transform.name.ToLower().Contains("trigger"))
	        {
	            switch (counter)
	            {
	                case 0:
                        lookAtPlayer();
	                    break;
                    case 1:
                        //moveCloser();
                        break;
                    case 2:
                        //moveCloser();
                        break;
                    default:
	                    break;
	            }
	            ++counter;
	        }
	    }
	}

    private void lookAtPlayer()
    {
        foreach (var angel in angels)
        {
            angel.LookAt(transform.position);
        }
    }

    private void moveCloser()
    {
        foreach (var angel in angels)
        {
            angel.Translate(angel.forward + new Vector3(20f, 0f, 20f));
        }
    }
}
