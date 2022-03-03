using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LookToMove : MonoBehaviour
{
    public GameObject ground;
    public Transform infoBubble;
    
    private new Transform camera;
    private Text infoText;

    private void Start()
    {
        camera = Camera.main.transform;
        if (infoBubble != null) infoText = GetComponentInChildren<Text>();
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
                if (infoBubble != null)
                {
                    infoText.text = "X:" + hit.point.x.ToString("F2") + ", " + hit.point.z.ToString("F2");
                    infoBubble.LookAt(camera.position);
                    infoBubble.Rotate(0, 180, 0);
                }
                transform.position = hit.point;
            }

        }
    }
}
