using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float xVelocity;
    public float yVelocity;
    public float xPosLeftLimit;
    public float xPosReset;
    public float yPosReset;

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + (xVelocity * Time.deltaTime),
            transform.localPosition.y + (yVelocity * Time.deltaTime), transform.localPosition.z);

        if (transform.localPosition.x <= xPosLeftLimit) {
            transform.localPosition = new Vector3(xPosReset, yPosReset, transform.localPosition.z);
        }
    }
}
