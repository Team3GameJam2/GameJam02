using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Sound : MonoBehaviour {

    public Collider playerCol;
    public AudioClip[] ImpactSound;
    private AudioSource audio;

    private bool iscoll = false;

	// Use this for initialization
	void Start () {

        playerCol = GetComponent<Collider>();
        audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        other = playerCol;
        if (iscoll == true)
        {
            audio.PlayOneShot(ImpactSound[Random.Range(0,1)]);
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        other = playerCol;
        iscoll = true;
    }

}
