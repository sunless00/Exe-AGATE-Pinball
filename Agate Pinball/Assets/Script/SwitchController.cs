using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum Switchstate
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public float score;

    public ScoreManager scoreManager;


    private Switchstate state;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toogle();
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = Switchstate.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = Switchstate.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toogle()
    {
        if (state == Switchstate.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }


    }
    private IEnumerator Blink(int times)
    {
        state = Switchstate.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = Switchstate.Off;

        StartCoroutine(BlinkTimerStart(5));
    }
    
    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
