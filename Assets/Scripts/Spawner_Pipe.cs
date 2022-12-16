using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Pipe : MonoBehaviour {

    [SerializeField]
    private GameObject Pipe_Holder;

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawner());
	}
	
	IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1.1f);
        Vector3 temp = Pipe_Holder.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        Instantiate(Pipe_Holder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
