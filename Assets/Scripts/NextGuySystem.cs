using UnityEngine;
using UnityEngine.UI;



public class NextGuySystem : MonoBehaviour
{
    [Header("Fruit List")]
    [SerializeField] private GuyMerge[] possibleFruits;

    [Header("Next Fruit UI")]
    [SerializeField] private Image nextFruitImage;

    [Header("Spawn")]
    [SerializeField] private Transform fruitSpawnPoint;

    private GuyMerge currentFruit;
    private GuyMerge nextFruit;

    private void Start()
    {
        currentFruit = GetRandomFruit();
        nextFruit = GetRandomFruit();

        UpdateNextFruitUI();
    }

    private GuyMerge GetRandomFruit()
    {
        if (possibleFruits == null || possibleFruits.Length == 0)
        {
            Debug.LogError("No fruits have been assigned!");
            return null;
        }

        return possibleFruits[Random.Range(0, possibleFruits.Length)];
    }

    public void DropFruit()
    {
        if (currentFruit == null)
            return;

        Instantiate(
            currentFruit.prefab,
            fruitSpawnPoint.position,
            Quaternion.identity
        );

        currentFruit = nextFruit;

        nextFruit = GetRandomFruit();

        UpdateNextFruitUI();
    }

    private void UpdateNextFruitUI()
    {
        if (nextFruitImage == null || nextFruit == null)
            return;

        nextFruitImage.sprite = nextguy.sprite;
    }

    public GuyMerge GetCurrentFruit()
    {
        return currentFruit;
    }
}
