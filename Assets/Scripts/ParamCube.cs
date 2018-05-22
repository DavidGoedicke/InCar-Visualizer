using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;
    Material material;

	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().materials[0];
	}

	// Update is called once per frame
	void Update () {
        /*
        if (useBuffer) {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
            Color color = new Color(AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band]);
            material.SetColor("_EmissionColor", color);
        } else {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
            Color color = new Color(AudioPeer.audioBand[band], AudioPeer.audioBand[band], AudioPeer.audioBand[band]);
            material.SetColor("_EmissionColor", color);
        }
        */
	}
}
