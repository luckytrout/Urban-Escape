using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform GetWP(int waypoint) 
    {
        return transform.GetChild(waypoint);
    }

    public int GetNextWP(int currentWP)
    {
        int next = currentWP+1;
        if(next == transform.childCount)
        {
            next = 0;
        }

        return next;
    }
}
