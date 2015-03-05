using UnityEngine;
using System.Collections;

public abstract class Visualizer : MonoBehaviour
{
    protected Transform[] children;

    private void Awake()
    {
        children = GetComponentsInChildren<Transform>();
    }

    public abstract void ChangeVisual(float value, float pitchValue);
}
