using UnityEngine;
using System.Collections;

public class Angel : MonoBehaviour
{

    private Transform player;
    private GameObject angelsAttacking;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        angelsAttacking = GameObject.Find("AngelsAttacking");
    }
}
