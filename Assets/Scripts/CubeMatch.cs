using UnityEngine;

public class CubeMatch : MonoBehaviour
{
    [Header("Match Settings")]
    public string cornerTag; // Tag of the correct color corner

    private bool hasMatched = false; // Keeps track so my player don’t double-count the same cube
    public static int matchedCount = 0; // Shared counter for all cubes

    [Header("Audio Settings")]
    public AudioClip matchSound; // Assignning the .wav sound from the Inspector
    private AudioSource audioSource; // It will be used to play the match sound

    void Start()
    {
        // Adding an AudioSource component automatically
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (!hasMatched && other.CompareTag(cornerTag))
        {
            hasMatched = true;
            matchedCount++;

            // It plays a satisfying sound when the cube finds its matching corner
            if (matchSound != null)
            {
                // Slight pitch variation just to make repeated matches sound less robotic
                audioSource.pitch = Random.Range(0.95f, 1.05f);
                audioSource.PlayOneShot(matchSound);
            }

            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.UpdateScoreText();
            }

            Debug.Log($"{gameObject.name} matched! Total matched cubes: {matchedCount}");
        }
    }
}
