using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Teleport : MonoBehaviour
{
    public GameObject[] Location;
    public GameObject MonsterFBX;
    public Transform monsterPosition;
    public VideoPlayer dead;
    NavMeshAgent nav;
    int i = 0;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(dead.time > 0.9)
        {
            Application.Quit();
        }
    }

    public void Trasport()
    {
        if(i == 0)
        {
            nav.SetDestination(Location[i].transform.position);
        }
        else if(i == 1)
        {
            nav.SetDestination(Location[i].transform.position);
        }
        else if(i == 2)
        {
            nav.SetDestination(Location[i].transform.position);
        }
        i++;
    }
    IEnumerator DespawnMonster()
    {
        yield return new WaitForSeconds(2f);
        MonsterFBX.GetComponent<NavMeshAgent>().SetDestination(monsterPosition.position);
    }

    private void OnCollisionExit(Collision collision)
    {
        StartCoroutine(DespawnMonster());
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger1"))
        {
            StartCoroutine(DespawnMonster());
        }
        if (other.gameObject.CompareTag("Trigger2"))
        {
            dead.Play();
            MonsterFBX.GetComponent<NavMeshAgent>().SetDestination(transform.position);
        } 
    }
}
