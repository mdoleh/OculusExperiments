using UnityEngine;

public class DecibelVisualizer : Visualizer
{
    public override void ChangeVisual(float dbValue, float pitchValue)
    {
        float value = dbValue / 5;
        if (value < 0.1) value = 0.1f;
        for (int i = 0; i < 10; ++i)
        {
            int index = Random.Range(0, children.Length - 1);
            if (children[index].childCount > 0) return;
            children[index].localScale = new Vector3(value, value, value);
        }
    }
}
