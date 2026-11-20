using Unity.VisualScripting;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject configured;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void DestroyConfigured()
    {
        Destroy(configured);
    }
}
