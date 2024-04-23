using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject Pumpkin;

    float Intervalo;
    // Start is called before the first frame update
    void Start()
    {
        Intervalo = Random.Range(1.5f, 3.5f);
        if (UI.AbóborasColetadas <= 20) StartCoroutine(SpawnBorba(Intervalo, Pumpkin));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnBorba(float _intervalo, GameObject _pumpkin)
    {
        yield return new WaitForSeconds(_intervalo);
        GameObject newPumpkin = Instantiate(_pumpkin, new Vector3(Random.Range(-70, 70),
        0.2f, Random.Range(5, 100)), Quaternion.identity);
        StartCoroutine(SpawnBorba(_intervalo, _pumpkin));
    }

}
