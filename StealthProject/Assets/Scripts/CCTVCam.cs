using UnityEngine;
using System.Collections;

public class CCTVCam : MonoBehaviour {

    void OnTriggerStay(Collider other) {
        if (other.tag == Tags.PLAYER) {
            GameController._instance.PlayerBeenFound(other.transform);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
