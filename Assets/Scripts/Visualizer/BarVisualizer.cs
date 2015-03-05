using UnityEngine;
using System.Collections;

public class BarVisualizer : Visualizer
{

    private Vector3 startScale;
    public float minValue = 1.0f;
    public float amplitude = 0.1f;
    private float randomAmplitude;

    private void Start()
    {
        startScale = transform.localScale;
    }

    public override void ChangeVisual(float dbValue, float pitchValue)
    {
        if (dbValue < 0) dbValue = 0;
        randomAmplitude = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3((dbValue * amplitude * randomAmplitude) + startScale.x, minValue, minValue);
    }
}
