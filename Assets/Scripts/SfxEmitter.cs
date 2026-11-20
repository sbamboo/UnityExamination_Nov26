using UnityEngine;

public class SfxEmitter : MonoBehaviour
{
    [SerializeField]
    private AudioSource playerHurt;


    public void PlayNamed(string name)
    {
        AudioSource source = new AudioSource();

        switch (name)
        {
            case "player-hurt": {
                source = playerHurt;
                break;
            }
        }

        source.Play();
    }
}
