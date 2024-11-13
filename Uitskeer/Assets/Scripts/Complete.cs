using System.Collections;
using UnityEngine;

public class Complete : MonoBehaviour
{
    public Animator anim;

    [SerializeField] private float transitionTime = 1f;

    public void TransitionToEndScreen()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        anim.SetTrigger("FadeOut");

        yield return new WaitForSeconds(transitionTime);
    }
}
