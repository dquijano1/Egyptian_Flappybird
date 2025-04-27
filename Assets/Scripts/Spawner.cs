using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Pipes prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    public float verticalGap = 3f;
    private bool isSpawning = false;
    public float chalice_speed= 2f;
    

    [SerializeField] private GameObject chalice;
    [SerializeField] private Text score;
    
    private void OnEnable()
    {
        chalice.SetActive(false);
        
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    public void StartSpawning()
    {
        isSpawning = true;
        float initialDelay = spawnRate * 2f;
        InvokeRepeating(nameof(Spawn), initialDelay, spawnRate);
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke(nameof(Spawn));
        if (chalice != null)
        {
            chalice.SetActive(true);
        }
    }

     private void MoveChaliceObject()
    {
        if (chalice != null)
        {

            chalice.transform.Translate(Vector3.left * chalice_speed * Time.deltaTime);
        }
    }

    private void Update()
    {
        
        if (chalice != null && chalice.activeSelf)
        {
            MoveChaliceObject();
        }
    }

    private void Spawn()
    {
        Pipes pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        pipes.gap = verticalGap;
    }

}
