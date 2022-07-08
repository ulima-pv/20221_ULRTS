using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum State
    {
        Move, Idle
    }

    public UnitTypeSO unitType;

    private Vector3 mDestination;
    private State mState = State.Idle;

    public void SetActive(bool v)
    {
        transform.Find("selector").gameObject.SetActive(v);
    }

    public void Move(Vector3 dest)
    {
        mState = State.Move;
        mDestination = dest;
    }

    private void Update()
    {
        if (mState == State.Move)
        {
            Vector3 dir = mDestination - transform.position;
            Vector3 mov = Time.deltaTime * unitType.data.speed * dir.normalized;
            transform.position += mov;
        }
        if (Vector3.Distance(transform.position, mDestination) < 0.5f)
        {
            mState = State.Idle;
        }
    }
}
