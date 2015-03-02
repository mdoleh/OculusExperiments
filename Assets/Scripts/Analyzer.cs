using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Analyzer : MonoBehaviour {

    int qSamples = 1024;  // array size
    float refValue = 0.1f; // RMS value for 0 dB
    float threshold = 0.02f;      // minimum amplitude to extract pitch
    float rmsValue;   // sound level - RMS
    float dbValue;    // sound level - dB
    float pitchValue; // sound pitch - Hz

    private float[] samples; // audio samples
    private float[] spectrum; // audio spectrum
    private float fSample;
    private float previous = 0f;

    private Visualizer visualizer;
    public static AudioSource audioSource;
    private bool songPlaying = false;

    void Start()
    {
        samples = new float[qSamples];
        spectrum = new float[qSamples];
        fSample = AudioSettings.outputSampleRate;
    }

    private void Awake()
    {
        visualizer = GetComponent<Visualizer>();
    }

    void AnalyzeSound()
    {
        audioSource.GetOutputData(samples, 0); // fill array with samples
        int i;
        float sum = 0f;
        for (i = 0; i < qSamples; i++)
        {
            sum += samples[i] * samples[i]; // sum squared samples
        }
        rmsValue = Mathf.Sqrt(sum / qSamples); // rms = square root of average
        dbValue = 20 * Mathf.Log10(rmsValue / refValue); // calculate dB
        if (dbValue < -160) dbValue = -160; // clamp it to -160dB min
        // get sound spectrum
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        int maxN = 0;
        for (i = 0; i < qSamples; i++)
        { // find max 
            if (spectrum[i] > maxV && spectrum[i] > threshold)
            {
                maxV = spectrum[i];
                maxN = i; // maxN is the index of max
            }
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < qSamples - 1)
        { // interpolate index using neighbours
            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchValue = freqN * (fSample / 2) / qSamples; // convert index to frequency
    }

    //public Text display; // drag a GUIText here to show results

    void Update()
    {
        if (!songPlaying && Time.time > 10)
        {
            audioSource.Play();
            songPlaying = true;
        }
        AnalyzeSound();
//        if (display)
//        {
//            display.text = "RMS: " + rmsValue.ToString("F2") +
//            " (" + dbValue.ToString("F1") + " dB)\n" +
//            "Pitch: " + pitchValue.ToString("F0") + " Hz";
//        }
        visualizer.ChangeVisual(dbValue, pitchValue);
    }
}
