using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    float originalPos = 0;
    float pos;
    float speed = 5;
    public Vector3 prefabPos;

    public GameObject[] prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveBack()
    {
        var x = transform.localEulerAngles.x;

        if (x >= 20)
        {
            pos = Mathf.MoveTowards(x, originalPos, Time.deltaTime * speed);
            Vector3 rotationToAdd = new Vector3(-pos, 0, 0);
            transform.Rotate(rotationToAdd);

            var which = Random.Range(0, prefab.Length);
            Instantiate(prefab[which], prefabPos, Quaternion.identity);
        }
    }
}
