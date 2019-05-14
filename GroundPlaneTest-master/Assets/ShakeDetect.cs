using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShakeDetect : MonoBehaviour
{
    public float threshold = 0.1f;
    public Vector3 accelPrev;

    public Text text;
    public Text accelT;
    public Slider slider;
    public Slider magSlider;

    MeshRenderer gRenderer;
    public Animator animator;
    public float duration;


    // Update is called once per frame
    void Update()
    {
        threshold = slider.value/magSlider.value;
        Vector3 accel = Input.acceleration;
        accelT.text = accel.ToString();
        float val = accel.magnitude;
        if((accelPrev-accel).sqrMagnitude > threshold)
        {
            Hit();
        }
        else
        {
            text.text = "Miss";
        }
    }

    public void Hit()
    {
        StopAllCoroutines();
        text.text = "Hit";
        StartCoroutine(HitRoutine());

    }
    private IEnumerator HitRoutine()
    {
        float currDur = duration;
        while (currDur > 0)
        {
            yield return null;
            currDur -= Time.deltaTime;
            animator.SetFloat("Blend",currDur/duration);
        }
    }
}
