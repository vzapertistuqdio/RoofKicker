using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    private Transform currentPoint;

    private NavMeshAgent myAgent;
    private Rigidbody botRigibody;
    private void Start()
    {
        currentPoint = point1;
        botRigibody = GetComponent<Rigidbody>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    
    private void Update()
    {
        if ( transform.position.x== currentPoint.position.x )
        {
            SwapPoint();
        }
        myAgent.SetDestination(currentPoint.position);
    }

    private void SwapPoint()
    {
        if(currentPoint==point1)
        {
            currentPoint = point2;
        }
        else if(currentPoint==point2)
        {
            currentPoint = point1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>()!=null)
        {
            myAgent.enabled = false;
            botRigibody.AddForce(other.GetComponent<Rigidbody>().velocity+Vector3.up*30,ForceMode.Impulse);
            StartCoroutine(DieAfterTime(3f));
        }
    }
    private IEnumerator DieAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
