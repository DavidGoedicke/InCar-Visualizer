using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour {
    AudioSource audioSource;
    public static float[] samples = new float[512];
    static float[] frequencyBand = new float[8];
    static float[] bandBuffer = new float[8];
    float[] bufferDecrease = new float[8];
    float[] freqBandHighest = new float[8];
    public float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
    }

    void GetSpectrumAudioSource() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands() {
        int count = 0;
        for (int i = 0; i < 8; i++) {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i + 1);
            if (i == 7) {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++) {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            frequencyBand[i] = average * 10;
        }
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g) {
            if (frequencyBand[g] > bandBuffer[g]) {
                bandBuffer[g] = frequencyBand[g];
                bufferDecrease[g] = 0.005f;
            }
            if (frequencyBand[g] < bandBuffer[g]) {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (frequencyBand[i] > freqBandHighest[i] || freqBandHighest[i] == float.NaN)
            {
                freqBandHighest[i] = frequencyBand[i];
            }
            Debug.Log("i");
            Debug.Log(i);
            Debug.Log("frequencyBand");
            Debug.Log(frequencyBand[i]);
            Debug.Log("frequencyBandHighest");
            Debug.Log(freqBandHighest[i]);
            if (freqBandHighest[i] == 0) {
                audioBand[i] = 0;
                audioBandBuffer[i] = 0;
            } else {
                audioBand[i] = frequencyBand[i] / freqBandHighest[i];
                audioBandBuffer[i] = bandBuffer[i] / freqBandHighest[i];
            }
        }
    }
}
