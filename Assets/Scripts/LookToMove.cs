using System.Collections;
using UnityEngine;

public class LookToMove : MonoBehaviour
{
    public GameObject ground;
    private new Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
    }

    private void Update()
    {
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        //Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100f);
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);

        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                transform.position = hit.point;
            }

        }
    }
}
