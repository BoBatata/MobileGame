using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Camera PlayerCamera;
    [SerializeField] GameObject mesh;

    Touch touch;
    Animation an;
    Ray ray;
    RaycastHit hit;
    AudioSource audio;
    AudioSource audio2;

    Vector3 Target = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        audio2 = mesh.GetComponent<AudioSource>();
        audio = GetComponent<AudioSource>();
        audio.Play();
        audio.volume = 0.8f;
        an = mesh.GetComponent<Animation>();
        an.CrossFade("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        Touch();
        Move();
    }

    private void Touch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                ray = PlayerCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Ground")
                    {
                        Target = hit.point;
                    }
                }
            }
        }
    }

    private void Move()
    {
        float distance = Vector3.Distance(transform.position, Target);
        if(distance <= 0f)
        {
            an.CrossFade("Idle");
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        transform.LookAt(Target);
        an.CrossFade("Run");
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Pumpkin"))
        {
            audio2.Play();
        }
    }
}
