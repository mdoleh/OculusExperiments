using UnityEngine;
using System.Collections;

public class PitchVisualizer : Visualizer
{
    public override void ChangeVisual(float dbValue, float pitchValue)
    {
        float value = pitchValue / 200;
        if (value < 0.1) value = 0.1f;
        for (int i = 0; i < 2; ++i)
        {
            int index = Random.Range(0, children.Length - 1);
            if (children[index].childCount > 0) return;
            children[index].GetComponent<Light>().intensity = value;
//            children[index].localScale = new Vector3(value, value, value);
        }
    }
}
