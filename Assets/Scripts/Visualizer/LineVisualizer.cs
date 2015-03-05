using UnityEngine;
using System.Collections;

public abstract class LineVisualizer : Visualizer
{

    protected float startPosition;
    protected float amplitude = 1.0f;

    private void Start()
    {
        startPosition = transform.localPosition.y;
    }
}
