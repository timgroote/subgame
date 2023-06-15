using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devfscr : MonoBehaviour
{

    public float turnRate = 10f;
    public float fdSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float i = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        fdSpeed += (v - fdSpeed) * Time.deltaTime;

        this.transform.rotation *= Quaternion.Euler(0,i * Time.deltaTime * turnRate,0) ;
        this.transform.position += this.transform.forward * (fdSpeed * Time.deltaTime);

    }
}
