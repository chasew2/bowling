using UnityEngine;
public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 1. ref to ball rigidbody and store in local var
        Rigidbody ballRigidBody = other.GetComponent<Rigidbody>();
        // 2. store velocity mangnitude
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
        // 3. reset both linear & angular velocity
    
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
        
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
}