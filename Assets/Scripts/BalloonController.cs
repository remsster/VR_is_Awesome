using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{

    public GameObject balloonPrefab;
    public float floatStrengh = 20f;
    public float growthRate = 1.5f;
    private GameObject balloon;
    //private ButtonInputController buttonController;

    private void Start()
    {
        //buttonController.ButtonDownEvent.AddListener(CreateBalloon);
        //buttonController.ButtonUpEvent.AddListener(ReleaseBalloon);
    }

    void Update()
    {
        //if (Input.GetButtonDown("XRI_Right_TriggerButton")) { CreateBalloon(); }
        //else if (Input.GetButtonUp("XRI_Right_TriggerButton")) { ReleaseBalloon(); }
        if (balloon != null) { GrowBalloon(); }
    }

    private void GrowBalloon()
    {
        float growThisFrame = growthRate * Time.deltaTime;
        Vector3 changeScale = balloon.transform.localScale * growThisFrame;
        balloon.transform.localScale += changeScale;
    }

    public void ReleaseBalloon()
    {
        balloon.transform.parent = null;
        balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrengh);
        GameObject.Destroy(balloon, 10f);
        balloon = null;

    }

    public void CreateBalloon(GameObject parentHand)
    {
        balloon = Instantiate(balloonPrefab, parentHand.transform);
        balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
