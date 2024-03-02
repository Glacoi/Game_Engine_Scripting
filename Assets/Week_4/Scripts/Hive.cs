using UnityEngine;

public class Hive : MonoBehaviour
{
    public float honeyProductionRate;
    public int startingBees;
    public GameObject beePrefab;

    private int nectarStored = 0;
    private int honeyStored = 0;
    private float honeyProductionTimer;
    private int currentBees = 0;

    private void Start()
    {
        for (int i = 0; i < startingBees; i++)
        {
            GameObject newBee = Instantiate(beePrefab, transform.position, Quaternion.identity);
            Bee beeComponent = newBee.GetComponent<Bee>();
            if (beeComponent != null)
            {
                beeComponent.Init(this);
                currentBees++;
            }
        }
    }

    private void Update()
    {
        if (nectarStored > 0)
        {
            honeyProductionTimer += Time.deltaTime;
            if (honeyProductionTimer >= honeyProductionRate)
            {
                honeyStored++;
                nectarStored--;
                honeyProductionTimer = 0f;
                if (nectarStored > 0)
                {
                    honeyProductionTimer = 0f; 
                }
            }
        }
    }

    public void GiveNectar()
    {
        nectarStored++;
        if (honeyProductionTimer <= 0)
        {
            honeyProductionTimer = 0.1f; 
        }
    }
}