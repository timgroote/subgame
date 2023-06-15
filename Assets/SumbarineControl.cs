using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SumbarineControl : MonoBehaviour
{

    public float Throttle = 0;

    public float EnginePowerKn = 10;

    private Rigidbody rbody;

    public float EffectiveBouyancy = 0;

    public Vector3 CenterOfMassOffset = new Vector3(0,0,0);

    public float RightingForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.centerOfMass = rbody.centerOfMass+CenterOfMassOffset;
    }

    // Update is called once per frame
    void Update()
    {

        rbody.AddForce(this.transform.forward * (Throttle * EnginePowerKn) * Time.deltaTime);

        rbody.AddForce(Vector3.down * (rbody.mass * Time.deltaTime) * -EffectiveBouyancy, ForceMode.Impulse);

        rbody.AddForceAtPosition(Vector3.up * RightingForce, this.transform.position + this.transform.up, ForceMode.Impulse);
        rbody.AddForceAtPosition(-Vector3.up * RightingForce, this.transform.position - this.transform.up, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        if(rbody != null)
        Gizmos.DrawWireSphere(rbody.worldCenterOfMass, 1);
    }
}
