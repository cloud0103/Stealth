using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public bool isFlicker = false;
    public float timer = 0;
    public float laserOnTime = 3;
    public float laserOffTime = 3;

    private Renderer laserRenderer;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            GameController._instance.PlayerBeenFound(other.transform);
        }
    }

    // Use this for initialization
    void Start () {
        laserRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (isFlicker) {
            if (laserRenderer.enabled) {
                if (timer > laserOnTime) {
                    laserRenderer.enabled = false;
                    timer = 0;
                }
            }
            if (!laserRenderer.enabled) {
                if (timer > laserOffTime) {
                    laserRenderer.enabled = true;
                    timer = 0;
                }
            }
        }
	}
}
