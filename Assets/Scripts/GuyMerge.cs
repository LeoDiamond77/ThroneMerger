using UnityEngine;

public class GuyMerge : MonoBehaviour
{
    [Header("Fruit Settings")]
    public int fruitLevel;

    // Put the next fruit prefab here in the Inspector.
    public GameObject nextFruitPrefab;

    private bool isMerging = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherFruit = collision.gameObject.GetComponent<GuyMerge>();

        if (otherFruit == null)
            return;

        // Only merge fruits of the same level.
        if (otherFruit.fruitLevel != fruitLevel)
            return;

        // Prevent both fruits from trying to merge at the same time.
        if (isMerging || otherFruit.isMerging)
            return;

        // Make sure only one of the two fruits performs the merge.
        if (GetInstanceID() > otherFruit.GetInstanceID())
            return;

        isMerging = true;
        otherFruit.isMerging = true;

        Vector2 mergePosition =
            (transform.position + otherFruit.transform.position) / 2f;

        Merge(otherFruit, mergePosition);
    }

    private void Merge(GuyMerge otherFruit, Vector2 position)
    {
        // Destroy the two old fruits.
        Destroy(gameObject);
        Destroy(otherFruit.gameObject);

        // Spawn the next fruit.
        if (nextFruitPrefab != null)
        {
            Instantiate(
                nextFruitPrefab,
                position,
                Quaternion.identity
            );
        }
    }
}