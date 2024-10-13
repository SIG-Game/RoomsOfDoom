using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float waveMagnitude;
    public float waveFrequency;
    public float waveOffset;

    private float yPosInitial;

    private void Start()
    {
        yPosInitial = transform.localPosition.y;
    }

    private void Update()
    {
        float yOffset = waveMagnitude * Mathf.Sin(waveFrequency * Time.time + waveOffset);
        transform.localPosition = new Vector3(transform.localPosition.x, yPosInitial + yOffset, transform.localPosition.z);
    }
}
