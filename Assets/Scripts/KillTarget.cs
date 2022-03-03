using UnityEngine;
using TMPro;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;

    public TextMeshProUGUI scoreText;

    private new Transform camera;
    private float countDown;



    private void Start()
    {
        camera = Camera.main.transform;
        score = 0;
        scoreText.text = "Score: 0";
        countDown = timeToSelect;
    }

    private void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == target) { isHitting = true; }
        }

        if (isHitting)
        {
            if (countDown > 0.0f)
            {
                // on target
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                if (hitEffect.isStopped) { hitEffect.Play(); }
            }
            else
            {
                // Killed
                GameObject clone = Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                scoreText.text = $"Score: {score}";
                countDown = timeToSelect;
                Destroy(clone, 3f);
                
                SetRandomPosition();
            }
        }
        else
        {
            // reset
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        target.transform.position = new Vector3(x, .5f, z);
    }

}
