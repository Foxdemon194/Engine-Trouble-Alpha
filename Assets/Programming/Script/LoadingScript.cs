using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject locomotionSystem;

    private float time = 5;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        locomotionSystem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            canvas.SetActive(false);
            locomotionSystem.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
