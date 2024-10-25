using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCircleCue : MonoBehaviour
{
    [SerializeField] Transform circleContourTransform; // Contour
    [SerializeField] bool isCircleContourDisplayed;
    public Transform circleTransform { get; set; }// The transform at which the circle will be centered
    public float radius { get; set; }  // Radius of the circle
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializeCircle(Vector3 circlePosition, float radius)
    {
        // Set the position and scale of the circle
        this.transform.position = circlePosition;
        this.transform.localScale = new Vector3(radius * 2, radius * 2, 1);

        // Deactivate circle contour by default
        DeactivateCircleContour();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isCircleContourDisplayed)
                ActivateCircleContour();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isCircleContourDisplayed)
                ActivateCircleContour();
        }
    }


    public void ActivateCircleContour()
    {
        circleContourTransform.gameObject.SetActive(true);
        // Start a coroutine to deactivate the object after 3 seconds
        StartCoroutine(DeactivateAfterDelay(3f, circleContourTransform.gameObject));
    }

    public void DeactivateCircleContour()
    {
        circleContourTransform.gameObject.SetActive(false);
    }

    IEnumerator DeactivateAfterDelay(float delay, GameObject gameObject)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Deactivate the object
        gameObject.SetActive(false);
    }
}
