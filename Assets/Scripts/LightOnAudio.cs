using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightOnAudio : MonoBehaviour {
    public int band;
    public float minIntensity, maxIntensity;
    Light light;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        light.intensity = (AudioPeer.audioBandBuffer[band] * (maxIntensity - minIntensity)) * minIntensity;
	}
}
