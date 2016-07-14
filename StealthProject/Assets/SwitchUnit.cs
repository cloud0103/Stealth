using UnityEngine;
using System.Collections;

public class SwitchUnit : MonoBehaviour {

    public GameObject screen;
    public Material unlockMat;
    public GameObject laser;

    private AudioSource switchUnit;
    private Renderer screenRenderer;

    void Start() {
        switchUnit = GetComponent<AudioSource>();
        screenRenderer = screen.GetComponent<Renderer>();
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == Tags.PLAYER) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                switchUnit.Play();
                screenRenderer.material = unlockMat;
                laser.SetActive(false);
            }
        }
    }
}
