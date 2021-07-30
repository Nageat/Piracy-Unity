using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrew : MonoBehaviour
{
    private float movementDuration = 1f;
    private float waitBeforeMoving = 0.05f;
    private bool hasArrived = false;
    public Transform[] Checkpoint;

  
    public void Awake()
    {
        Checkpoint = new Transform[11];
        GameObject[] tObjects = GameObject.FindGameObjectsWithTag("CrewMove");
        for (int i = 0; i < Checkpoint.Length; i++)
        {
            Checkpoint[i] = tObjects[i].transform;
        }
    }
    private void Update()
    {
        if (!hasArrived)
        {
            hasArrived = true;
           /* float randX = Random.Range(0f, 4.01f);
            float randY = Random.Range(0.29f, 2.70f);
            waitBeforeMoving = Random.Range(0.25f, 1f);
            movementDuration = Random.Range(1f, 1.50f);*/
            Transform Next = Checkpoint[Random.Range(0, Checkpoint.Length)].transform;
            StartCoroutine(MoveToPoint(new Vector3(Next.position.x, -2.039f, Next.position.z)));
            //StartCoroutine(MoveToPoint(new Vector3(randX, 0, randY)));

        }
    }

    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;
    }
}
