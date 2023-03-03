using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPracticeDestination : MonoBehaviour
{
    [SerializeField] GameObject TargetCircle;
    [SerializeField] AudioSource TargetAudio;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        TargetCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Camera.main.transform.position, this.transform.position);
        if (distance < 30f)
        {
            Debug.Log("distance |Camera.main - trigger|: " + distance);
            TargetCircle.transform.position = new Vector3(this.transform.position.x, 0.1f, this.transform.position.z);
            TargetCircle.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable New route
            Transform route = this.transform.parent.transform;
            int index = route.GetSiblingIndex();
            if (index + 1 < route.parent.childCount)
            {
                var next_route = route.parent.GetChild(index + 1).gameObject;
                next_route.SetActive(true);
                // ColorGlobal.CurrentRoute = next_route.name;
            }
            else
            {
                // ColorGlobal.CurrentRoute = "End of Routes (Practice)";
                Debug.Log("End of Routes (Practice) !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                route.gameObject.SetActive(false);
            }

            // auditory and visual feedback
            TargetAudio.Play();
            TargetCircle.SetActive(false);

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the Current Segment of Route
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
