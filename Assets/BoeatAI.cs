using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoeatAI : MonoBehaviour
{
    public float movementDuration;
    public float waitBeforeMoving;
    public bool hasArrived = false;
    public Transform[] Checkpoint;
    public Transform Boeat;
    public int cpt = 0;

    public void Awake()
    {

    }


    private void Update()
    {
        if (cpt > Checkpoint.Length)
        {
            cpt = 0;
        }

        if (!hasArrived && cpt < Checkpoint.Length)
        {
            Transform Next = Checkpoint[cpt].transform;

            Vector2 Depart = new Vector2(Boeat.position.x, Boeat.position.y);
            Vector2 Arriver = new Vector2(Next.position.x, Next.position.y);

            Vector2 difference = (Arriver - Depart).normalized;
            Boeat.LookAt(difference);


            StartCoroutine(MoveToPoint(new Vector2(Next.position.x, Next.position.y)));
            hasArrived = true;
            
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
        cpt += 1;

        hasArrived = false;
    }
}
