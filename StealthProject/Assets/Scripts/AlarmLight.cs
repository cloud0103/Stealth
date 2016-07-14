using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {

    public static AlarmLight _instance;

    public bool alarmOn = false;
    public float animationSpeed = 3;

    private Light alarmLight;
    private float lowIntensity = 0;
    private float highIntensity = 1;
    private float targetIntensity;

    void Awake() {

        _instance = this;

        targetIntensity = highIntensity;
        alarmOn = false;
    }

	// Use this for initialization
	void Start () {
        alarmLight = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        if (alarmOn == true)
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetIntensity, Time.deltaTime * animationSpeed);
            if (Mathf.Abs(alarmLight.intensity - targetIntensity) < 0.05f) {
                if (targetIntensity == highIntensity) targetIntensity = lowIntensity;
                else {
                    if (targetIntensity == lowIntensity) targetIntensity = highIntensity;
                }
            }
        }
        else {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, lowIntensity, Time.deltaTime * 3);
        }
    }
}
