using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    public GameObject Player;
    public Transform playerTransform;
    public float MoveSpeed = 3.5f;
    public int MaxDist = 10;
    public int MinDist = 5;
    private int damage;
    private Animator anim;
    private int attackHash = Animator.StringToHash("Attack");
    private int deathHash = Animator.StringToHash("Death");
    private int waitHash = Animator.StringToHash("Wait");
    private bool dieing;
    private float dmgRate = 1.067f;
    private float nextDmg = 0.0f;

    // Use this for initialization
    void Start () {
        dieing = false;
        damage = 0;
        anim = GetComponent<Animator>();
        anim.SetBool(waitHash, true);
        Player = GameObject.Find("OVRPlayerController");
        playerTransform = Player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(RoundStart());
    }

    public void Hit()
    {
        damage += 1;
    }

    IEnumerator RoundStart()
    {
        // Delay round start for 5 seconds
        yield return new WaitForSeconds(5);

        // Turn off idle animation
        anim.SetBool(waitHash, false);

        // Enemy rotation always set to look at player
        transform.LookAt(playerTransform);

        if (damage < 5)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) >= MinDist)
            {
                // Enemy running
                anim.SetBool(attackHash, false);
                Vector3 forward = transform.forward;
                forward.Set(forward.x, 0, forward.z);
                transform.position += forward * MoveSpeed * Time.deltaTime;

                // Player stops taking damage
                CancelInvoke();

                if (Vector3.Distance(transform.position, playerTransform.position) <= MaxDist)
                {
                    // Enemy attacking
                    anim.SetBool(attackHash, true);

                    // Damage to player
                    InvokeRepeating("Attack", 0f, 1.067f);
                }

            }
        }
        else if(!dieing)
        {
            Debug.Log("Die");
            // Enemy dies
            StartCoroutine(Death());
        }
    }

    void Attack()
    {
        // Delay on attack damage (timed with length of animation)
        if (Time.time > nextDmg)
        {
            nextDmg = Time.time + dmgRate;
            ProgressionInterface.SubHealth(5);
        }
    }

    IEnumerator Death()
    {
        dieing = true;
        ProgressionInterface.EnemyDeath();

        anim.SetTrigger(deathHash);

        // Wait for full animation to finish
        yield return new WaitForSeconds(8);

        Destroy(gameObject);
    }
}
