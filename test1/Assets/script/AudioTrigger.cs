using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;

    private bool[] hasPlayedAudio = new bool[5];

    void Start()
    {
        // Initialize the hasPlayedAudio array
        for (int i = 0; i < hasPlayedAudio.Length; i++)
        {
            hasPlayedAudio[i] = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == object1 && !hasPlayedAudio[0])
        {
            PlayAudio(object1);
            hasPlayedAudio[0] = true;
        }
        else if (other.gameObject == object2 && !hasPlayedAudio[1])
        {
            PlayAudio(object2);
            hasPlayedAudio[1] = true;
        }
        else if (other.gameObject == object3 && !hasPlayedAudio[2])
        {
            PlayAudio(object3);
            hasPlayedAudio[2] = true;
        }
        else if (other.gameObject == object4 && !hasPlayedAudio[3])
        {
            PlayAudio(object4);
            hasPlayedAudio[3] = true;
        }
        else if (other.gameObject == object5 && !hasPlayedAudio[4])
        {
            PlayAudio(object5);
            hasPlayedAudio[4] = true;
        }
    }

    private void PlayAudio(GameObject obj)
    {
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
