using UnityEngine;

[System.Serializable]
public class FishPrefab
{
    public GameObject fishPrefab;
    public int tapsRequired;
}

public class FishingMinigame : MonoBehaviour
{
    public Collider waterCollider;
    public float minCastingTime = 1f;
    public float maxCastingTime = 3f;
    public float tapTimeLimit = 2f;
    public FishPrefab[] fishPrefabs;

    private bool isFishing = false;
    private float castingTime;
    private float tapTimer;
    private int tapCount;
    private GameObject currentFishPrefab;
    private int currentTapsRequired;

    private void Start()
    {
        ResetFishing();
    }

    private void Update()
    {
        if (isFishing)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                tapCount++;
                tapTimer = tapTimeLimit;

                if (tapCount >= currentTapsRequired)
                {
                    CatchFish();
                }
            }

            tapTimer -= Time.deltaTime;
            if (tapTimer <= 0f)
            {
                ResetFishing();
            }
        }
    }

    private void ResetFishing()
    {
        isFishing = false;
        castingTime = Random.Range(minCastingTime, maxCastingTime);
        tapCount = 0;
        tapTimer = 0f;
        Invoke("StartFishing", castingTime);
    }

    private void StartFishing()
    {
        if (waterCollider.bounds.Contains(transform.position))
        {
            int randomIndex = Random.Range(0, fishPrefabs.Length);
            currentFishPrefab = fishPrefabs[randomIndex].fishPrefab;
            currentTapsRequired = fishPrefabs[randomIndex].tapsRequired;
            isFishing = true;
            Debug.Log("Fish is biting! Tap the screen " + currentTapsRequired + " times!");
        }
    }

    private void CatchFish()
    {
        GameObject fish = Instantiate(currentFishPrefab, transform.position, Quaternion.identity);
        Debug.Log("Congratulations! You caught the fish!");

        ResetFishing();
    }
}
