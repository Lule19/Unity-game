using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnInterval = 3f;
    public float spawnHeight = 7f;
    public float spawnZ = 20f;
    public float spawnXRange = 2f;

    public Renderer boxRenderer; 
    public Color transparentColor = new Color(1f, 1f, 1f, 0.1f); 

    private float timer = 0f;
    private bool canSpawn = false; 
    private Color nextColor;       

    void Start()
    {
        if (boxRenderer != null)
            boxRenderer.material.color = transparentColor; 
    }

    void Update()
    {
        if (!canSpawn) return; 

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0f;
        }
    }

    void SpawnBall()
    {
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, spawnZ);

        GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        Renderer rend = newBall.GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = nextColor;


        PickNextColor();
    }

    public void SetSpawning(bool value)
    {
        canSpawn = value;

        
        if (canSpawn)
            PickNextColor();
        else if (boxRenderer != null)
            boxRenderer.material.color = transparentColor; 
    }

    void PickNextColor()
    {
        Color[] colors = { Color.red, Color.green, Color.blue };
        nextColor = colors[Random.Range(0, colors.Length)];

        if (boxRenderer != null)
            boxRenderer.material.color = nextColor; 
    }

  
}
