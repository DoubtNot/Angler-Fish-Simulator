using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    public RectTransform miniMapIcon;
    public Transform player;

    // The position and scale of the mini-map (to adjust the icon position correctly).
    public RectTransform miniMapRect;
    public Vector2 mapDimensions = new Vector2(100f, 100f); // The size of your mini-map background in Unity units.

    // The amount to shift the player icon's position on the x and y axes.
    public float xOffset = 10f;
    public float yOffset = 10f;

    private void Update()
    {
        // Get the player's position in world space and convert it to the mini-map's local space.
        Vector3 playerPosition = player.position;
        Vector3 miniMapPosition = new Vector3(
            ((playerPosition.x + xOffset) / mapDimensions.x) * miniMapRect.rect.width,
            ((playerPosition.z + yOffset) / mapDimensions.y) * miniMapRect.rect.height,
            0f
        );

        // Set the position of the mini-map icon relative to the mini-map's center.
        miniMapIcon.localPosition = miniMapPosition;

        // Calculate the angle of rotation for the mini-map icon based on the player's rotation.
        float playerAngle = player.eulerAngles.y;
        float iconRotation = 180f - playerAngle; // Adjust for icon's initial rotation (if necessary).

        // Apply the rotation to the mini-map icon.
        miniMapIcon.localEulerAngles = new Vector3(0f, 0f, iconRotation);
    }
}
