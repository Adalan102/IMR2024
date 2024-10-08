using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RunningScript : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;
    private Animator animator;
    public bool isRunning = false;
    private Vector3 previousPosition;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        animator = GetComponent<Animator>();
        previousPosition = mObserverBehaviour.transform.position;
    }

    void Update()
    {
        if (mObserverBehaviour && mObserverBehaviour.TargetStatus.Status == Status.TRACKED)
        {
            Vector3 direction = mObserverBehaviour.transform.position - previousPosition;
            if (direction != Vector3.zero)
            {
                isRunning = true;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
            else
            {
                isRunning = false;
            }
            previousPosition = mObserverBehaviour.transform.position;
        }
        else
        {
            isRunning = false;
        }

        animator.SetBool("isRunning", isRunning);
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        Debug.Log("Target Status Changed: " + targetStatus.Status + ", " + targetStatus.StatusInfo);
        if (targetStatus.Status != Status.TRACKED)
        {
            isRunning = false;
        }
    }
}