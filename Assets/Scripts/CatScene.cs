using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScene : MonoBehaviour
{
    public GameObject timeline;
    public GameObject timelineEnd;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        timelineEnd.SetActive(false);
        timeline.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        timeline.SetActive(false);
        timelineEnd.SetActive(true);
    }


}
