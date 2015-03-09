using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Transform[] angels;
    public GameObject angelsAttacking;
    public AudioSource surprise;
    public AudioSource ambient;
    private bool triggered = false;
    private bool done = false;

	void Update ()
	{
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
	    if (!done && Physics.Raycast(ray, out hit, 1000))
	    {
	        if (hit.collider.transform.name.ToLower().Contains("trigger"))
	        {

                Debug.Log("trigger found");
	            if (!triggered) moveCloser();
	            triggered = true;
	        }
	        else
	        {
	            triggered = false;
	        }
	    }
	    if (!surprise.isPlaying && done)
	    {
            Application.LoadLevel("Oculus_Spook");
	    }
	}

    private void moveCloser()
    {
        foreach (var angel in angels)
        {
            angel.LookAt(transform.position);
            var multiplier = 1;
            if (angel.transform.name.ToLower().Contains("reverse")) multiplier = -1;
            angel.Translate(angel.forward * multiplier * 2f);
            if (Math.Abs(angel.position.x - transform.position.x) <= 10f && Math.Abs(angel.position.z - transform.position.z) <= 10f)
            {
                angel.parent.gameObject.SetActive(false);
                angelsAttacking.SetActive(true);
                ambient.Stop();
                surprise.Play();
                done = true;
            }
        }
        Debug.Log("angels moved");
    }
}
