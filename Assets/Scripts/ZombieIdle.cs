using UnityEngine;

public class ZombieIdle : StateMachineBehaviour
{
    [SerializeField] public static float chaseRange = 5f;

    private Transform _target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, _target.position) <= chaseRange)
        {
            animator.SetBool("IsChasing", true);
        }
    }
}
