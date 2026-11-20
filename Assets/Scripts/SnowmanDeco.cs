using UnityEngine;

public class SnowmanDeco : MonoBehaviour
{
    public void TriggerIt()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        sr.color = Color.blueViolet;
    }
}
