using UnityEngine;

public class Flower : MonoBehaviour
{
    public float nectarProductionRate;
    public float nectarProductionTimer;
    public float counter;

    public bool hasNectar;
    public Color nectarReadyColor;
    public Color nectarNotReadyColor;
    private SpriteRenderer spriteRenderer;

    private void Start()
{
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.color = nectarNotReadyColor;
    gameObject.SetActive(true); 
}

    private void Update()
    {
        if (!hasNectar)
        {
            counter += Time.deltaTime;
            if (counter >= nectarProductionRate)
            {
                hasNectar = true;
                counter = 0f;
                spriteRenderer.color = nectarReadyColor;
            }
        }
    }

    public void NotifyBees()
    {
        
    }

    public bool TakeNectar()
    {
        if (hasNectar)
        {
            hasNectar = false;
            spriteRenderer.color = nectarNotReadyColor;
            nectarProductionTimer = 0f; 
            return true;
        }
        else
        {
            return false;
        }
    }
}