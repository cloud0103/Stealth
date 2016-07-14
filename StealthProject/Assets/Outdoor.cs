using UnityEngine;
using System.Collections;

public class Outdoor : MonoBehaviour {

    private int count = 0;
    private Animator anim;
    public AudioSource doorAudio;
    public AudioSource audioAccesDenied;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            if (other.GetComponent<Player>().hasKey)
            {
                anim.SetBool("isClosed", false);
            }
        }
        else {
            audioAccesDenied.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            if (other.GetComponent<Player>().hasKey) {
                anim.SetBool("isClosed", true);
            }
        }
    }


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.IsInTransition(0))
        {
            doorAudio.Play();
        }
    }
}
