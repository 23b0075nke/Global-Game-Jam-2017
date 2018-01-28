using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StarfieldObject : MonoBehaviour
{
    [SerializeField]
    private string triggerName = "play";
    [SerializeField]
    private Vector3 rotateRange = Vector3.right;

    private Animator animator = null;
    private StarfieldBackgroundGenerator generator;

    public Animator Animator
    {
        get
        {
            if(animator == null)
            {
                animator = GetComponent<Animator>();
            }
            return animator;
        }
    }

    public void Setup(StarfieldBackgroundGenerator generator)
    {
        this.generator = generator;
        NextLocation();
    }

    public void NextLocation()
    {
        if(generator != null)
        {
            StartCoroutine(DelayAnimate(generator.NextDelay));
        }
    }

    IEnumerator DelayAnimate(float delay)
    {
        // Position this star at a new location
        transform.position = generator.GetRandomStarPosition(this);
        transform.Rotate(rotateRange * Random.value);

        // Delay the time
        yield return new WaitForSeconds(delay);

        // Animate
        Animator.SetTrigger(triggerName);
    }
}
