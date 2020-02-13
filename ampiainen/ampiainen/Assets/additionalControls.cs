using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class additionalControls : MonoBehaviour
{
    public Collider axe;
    public UnityEngine.Events.UnityEvent diee;
    public UnityEngine.Events.UnityEvent hitt;
    public void die()
    {
        diee.Invoke();
    }
    public void hit()
    {
        hitt.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            hit();
            axe.enabled = true;
            StartCoroutine(tee());
        }
    }
    IEnumerator tee()
    {
        yield return new WaitForSeconds(.5f);
        axe.enabled = !axe.enabled;
        if (axe.enabled)
            StartCoroutine(tee());
    }
}
