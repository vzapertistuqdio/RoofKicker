using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private float timeToDestroy;
    private Animator plankAnim;

    private bool readyToDrop = false;
    private void Start()
    {
        plankAnim = GetComponent<Animator>();
        timeToDestroy = Random.Range(5, 20);
        StartCoroutine(DestroyAfterTime(timeToDestroy));
    }

    private void Update()
    {
        if(readyToDrop)
        {
            transform.Translate(0, -0.1f, 0);
        }
        
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time-2f);
        Lightning();
        yield return new WaitForSeconds(2f);
        readyToDrop = true;
    }
    private void Lightning()
    {
        plankAnim.SetTrigger("light");
    }
}
