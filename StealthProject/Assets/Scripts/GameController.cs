using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController _instance;

    public bool alarmOn = false;
    public Vector3 lastPlayerPosition = Vector3.zero;

    private GameObject[] sirens;
    public AudioSource normalBGM;
    public AudioSource panicBGM;

    void Awake () {
        _instance = this;
        alarmOn = false;        
    }

	// Use this for initialization
	void Start () {
        sirens = GameObject.FindGameObjectsWithTag(Tags.SIREN);
        //if (sirens == null) Debug.Log("sirens is null");
    }
	
	// Update is called once per frame
	void Update () {
        AlarmLight._instance.alarmOn = alarmOn;

        if (alarmOn)
        {
            PlaySiren();
            Mathf.Lerp(normalBGM.volume, 0,Time.deltaTime);
            Mathf.Lerp(panicBGM.volume, 1,Time.deltaTime);
        }
        else {
            StopSiren();
            Mathf.Lerp(normalBGM.volume, 1, Time.deltaTime);
            Mathf.Lerp(panicBGM.volume, 0, Time.deltaTime);
        }
	}

    private void PlaySiren() {
        foreach (GameObject go in sirens) {
            if (!go.GetComponent<AudioSource>().isPlaying) {
                go.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void StopSiren() {
        foreach (GameObject go in sirens) {
                go.GetComponent<AudioSource>().Stop();
        }
    }

    public void PlayerBeenFound(Transform player) {
        alarmOn = true;
        lastPlayerPosition = player.transform.position;
    }

    }
