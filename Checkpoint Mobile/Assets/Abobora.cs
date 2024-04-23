using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abobora : MonoBehaviour
{
    Transform target;

    [SerializeField] float Speed;
    [SerializeField] float TimeToDestroy;
    [SerializeField] float minDistance;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Magnet();
        Destroy();
    }

    void Magnet ()
    {
        if(target != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if(distance < minDistance)
            {
                Vector3 Position = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                
            }
         
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.AbóborasColetadas++;
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject, TimeToDestroy);
    }
}
