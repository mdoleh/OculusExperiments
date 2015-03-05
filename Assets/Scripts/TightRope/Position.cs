using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(-2.73f, 61.89f, 10.61f);
    }
}
