using UnityEngine;

public class ZombieWalk : StateMachineBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float attackRange = 1.5f;

    private Transform _target;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveTowardsPlayer(animator);
        VerifyDistance(animator);
    }

    private void MoveTowardsPlayer(Animator animator)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, _target.position, speed * Time.deltaTime);
        Vector2 lookDir = _target.transform.position - animator.transform.position;
        animator.transform.up = -lookDir;
    }

    private void VerifyDistance(Animator animator)
    {
        float distance = Vector2.Distance(animator.transform.position, _target.position);

        if (distance > ZombieIdle.chaseRange)
        {
            animator.SetBool("IsChasing", false);
        }

        if (distance < attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }
}
