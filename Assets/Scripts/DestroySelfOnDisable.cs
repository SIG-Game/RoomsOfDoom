using UnityEngine;

public class DestroySelfOnDisable : MonoBehaviour
{
    void OnDisable()
    {
        Destroy(gameObject);
    }
}
