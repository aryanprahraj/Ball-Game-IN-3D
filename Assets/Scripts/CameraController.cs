using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Let me reference it to the player object
    public GameObject player;

    // Now, let's store the initial offset between the camera and player that is sphere in my case
    private Vector3 offset;

    // Running it once before the first frame update
    void Start()
    {
        // Calculating the initial distance between camera and player
        offset = transform.position - player.transform.position;
    }

    // LateUpdate runs after all Update() calls
    void LateUpdate()
    {
        // camera following the player
        transform.position = player.transform.position + offset;
    }
}
