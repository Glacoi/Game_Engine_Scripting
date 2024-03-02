using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Bee : MonoBehaviour
{
    private Hive hive;

    private void Start()
    {
        CheckAnyFlower();
    }

    public void Init(Hive hive)
    {
        this.hive = hive;
    }

    private List<Flower> visitedFlowers = new List<Flower>();

    private void CheckAnyFlower()
    {
        Flower[] flowers = FindObjectsOfType<Flower>(true);

        if (flowers.Length > 0)
        {
            List<Flower> unvisitedFlowers = new List<Flower>();

            foreach (Flower flower in flowers)
            {
                if (!visitedFlowers.Contains(flower))
                {
                    unvisitedFlowers.Add(flower);
                }
            }

            if (unvisitedFlowers.Count > 0)
            {
                Flower targetFlower = unvisitedFlowers[Random.Range(0, unvisitedFlowers.Count)];

                if (targetFlower.TakeNectar())
                {
                    visitedFlowers.Add(targetFlower);

                    FlyTo(targetFlower.transform.position, () =>
                    {
                        FlyTo(hive.transform.position, () =>
                        {
                            hive.GiveNectar();
                            visitedFlowers.Remove(targetFlower);
                            CheckAnyFlower();
                        });
                    });
                }
                else
                {
                    CheckAnyFlower();
                }
            }
            else
            {
                visitedFlowers.Clear();
            }
        }
    }

    private void FlyTo(Vector3 targetPosition, TweenCallback onComplete = null)
    {
        transform.DOMove(targetPosition, 2f).OnComplete(onComplete);
    }
}
