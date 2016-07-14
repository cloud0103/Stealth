using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    private int count = 0;
    private Animator anim;
    public AudioSource doorAudio;

    void OnTriggerEnter(Collider other) {
        if (other.tag == Tags.PLAYER || other.tag == Tags.ENEMY) {
            count++;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == Tags.PLAYER || other.tag == Tags.ENEMY)
        {
            count--;
        }
    }


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("isClosed", count <= 0);
        if (anim.IsInTransition(0)) {
            doorAudio.Play();
        }
	}
}
