using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    public GameObject toActivate;

    void Awake()
    {
        toActivate.SetActive(true);
    }
}
