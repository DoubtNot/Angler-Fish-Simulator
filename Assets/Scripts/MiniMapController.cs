using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    public RectTransform miniMapIcon;
    public Transform player;

    // The position and scale of the mini-map (to adjust the icon position correctly).
    public RectTransform miniMapRect;
    public Vector2 mapDimensions = new Vector2(100f, 100f); // The size of your mini-map background in Unity units.

    private void Update()
    {
        // Get the player's position in world space and convert it to the mini-map's local space.
        Vector3 playerPosition = player.position;
        Vector3 miniMapPosition = new Vector3(
            (playerPosition.x / mapDimensions.x) * miniMapRect.rect.width,
            (playerPosition.z / mapDimensions.y) * miniMapRect.rect.height,
            0f
        );

        // Set the position of the mini-map icon.
        miniMapIcon.localPosition = miniMapPosition;
    }
}
