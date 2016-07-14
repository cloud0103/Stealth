using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed = 1;
    public float rotateSpeed = 1;
    public bool hasKey = false;

    private Animator anim;
    private AudioSource footStep;

    void Awake() {
        anim = GetComponent<Animator>();
        hasKey = false;
    }

	// Use this for initialization
	void Start () {
        footStep = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            float newSpeed = Mathf.Lerp(anim.GetFloat("Speed"), 5.6f, Time.deltaTime * moveSpeed);
            anim.SetFloat("Speed", newSpeed);

            Vector3 targetDir = new Vector3(h, 0, v);
            Quaternion newRotation = Quaternion.LookRotation(targetDir,transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime*rotateSpeed);
        }
        else {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isSneak", true);
        }
        else {
            anim.SetBool("isSneak", false);
        }

        //如果当前active的动画是Locomotion，就播放脚步声
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            PlayFootStepAudio();
        }
        else {
            StopFootStepAudio();
        }
    }

    private void PlayFootStepAudio() {
        if (!footStep.isPlaying) {
            footStep.Play();
        }
    }

    private void StopFootStepAudio()
    {
        if (footStep.isPlaying)
        {
            footStep.Stop();
        }
    }
}
