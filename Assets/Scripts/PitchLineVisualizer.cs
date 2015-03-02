using UnityEngine;
using System.Collections;

public class PitchLineVisualizer : LineVisualizer {

    public override void ChangeVisual(float dbValue, float pitchValue)
    {
        transform.position = new Vector3(transform.position.x, startPosition + dbValue * amplitude, transform.position.z);
    }
}
