using UnityEngine;

public class CompassController : MonoBehaviour
{
    public Transform player;
    public RectTransform compassNeedle;

    private void Update()
    {
        if (player != null && compassNeedle != null)
        {
            // Get the player's rotation around the Y-axis.
            float playerAngle = player.eulerAngles.y;

            // Calculate the angle to rotate the compass needle.
            float compassRotation = 360f - playerAngle;

            // Apply the rotation to the compass needle.
            compassNeedle.localEulerAngles = new Vector3(0f, 0f, compassRotation);
        }
    }
}
