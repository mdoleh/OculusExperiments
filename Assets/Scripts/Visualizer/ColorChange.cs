using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

    public float changeColourTime = 1000.0f;
     
    private float lastChange = 0.0f;
    private float timer = 0.0f;
    private Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    void Update() 
    {
         
        timer += Time.deltaTime;
         
        if (timer > changeColourTime) {
            timer = 0.0f;
        }

        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);
        Color newColor = new Color(red, green, blue, 1.0f);
        if (light != null) light.color = Color.Lerp(light.color, newColor, timer / changeColourTime);
    }
}
