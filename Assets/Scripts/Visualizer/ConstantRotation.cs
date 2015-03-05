using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour
{

    public float speed = 10.0f;

    void Update () {
        transform.Rotate(0, speed * Time.deltaTime, 0);
	}
}
