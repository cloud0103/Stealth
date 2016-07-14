using UnityEngine;
using System.Collections;

public class KeyCard : MonoBehaviour {

    public AudioClip audio_pickUpKey;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PLAYER) {
            Player player = other.GetComponent<Player>();
            player.hasKey = true;
            AudioSource.PlayClipAtPoint(audio_pickUpKey,transform.position);
            Destroy(this.gameObject);
        }
    }
}
