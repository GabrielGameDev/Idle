using UnityEngine;
using UnityEngine.AI;

public class CharacterMiner : MonoBehaviour
{

    public Transform destinationPoint;
    NavMeshAgent agent;
    float timer;
    bool collecting = false;
    CollectArea collectArea;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destinationPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (collecting)
        {
            timer += Time.deltaTime;
            if (timer >= collectArea.interval)
            {
                LevelManager.instance.AddResource(collectArea.resource, collectArea.amount);
                timer = 0;

            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        CollectArea area = other.GetComponent<CollectArea>();
        if (area != null)
        {
            collectArea = area;
            collecting = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        CollectArea area = other.GetComponent<CollectArea>();
        if (area != null)
        {
            collectArea = null;
            collecting = false;
        }
    }
}
