using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Sound : MonoBehaviour {

    public AudioClip[] ImpactSound;
    private AudioSource audio;

    private bool iscoll = false;

	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   

    private void OnCollisionEnter(Collision collision)
    {
        if (iscoll == true)
        {
            audio.PlayOneShot(ImpactSound[Random.Range(0, 1)]);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        iscoll = true;
    }
}
