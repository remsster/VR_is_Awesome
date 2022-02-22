using System.Collections;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public float waitTime = 3f;

    private void Start()
    {
        StartCoroutine(RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay()
    {
        while(true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        transform.position = new Vector3(x, 0, z);
    }
}
