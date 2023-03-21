using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    DigScript dig;

    SpriteRenderer sr;

    Animator anim;
    string currentAnimation;

    [HideInInspector] public Vector2 lastDirection;

    //public bool Animating => !PlayerCombat.Instance.Dead && !PlayerCombat.Instance.Damaged;

    // Start is called before the first frame update
    void Start()
    {
        //combat = GetComponent<PlayerCombat>();

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Play("Dig" + DirectionToString());


        }
        else
        {
            Play(GetNormalAnimation());

        }
    }

    string GetNormalAnimation()
    {
        string a = "Idle";

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (input != Vector2.zero)
        {
            lastDirection = input;
            a = "Walk";
        }

        a += DirectionToString();

        return a;
    }

    public string DirectionToString()
    {
        string a = "Down";

        if (lastDirection.x != 0f && Mathf.Abs(lastDirection.x) > Mathf.Abs(lastDirection.y))
        {
            sr.flipX = lastDirection.x < 0f;
            a = "Side";
        }
        else if (lastDirection.y > 0f)
        {
            a = "Up";
        }

        return a;
    }

    public void Play(string a)
    {
        if (a == currentAnimation)
            return;

        currentAnimation = a;
        anim.Play(a);
    }
}
