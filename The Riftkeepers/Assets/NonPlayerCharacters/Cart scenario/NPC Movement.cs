using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Animator mAnimator; // Model Animator
    [Header("References")]
    public Transform player;

    [Header("Variables")]
    public float talkingRange = 7;

    private bool talking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position);
        direction.y = 0;

        float distance = direction.magnitude;
        direction.Normalize();


        if (!talking && distance <= talkingRange)
        {
            talking = true;

        }

        if (talking && distance > talkingRange)
        {
            talking = false;

        }

        mAnimator.SetBool("talk", talking);
    }
}
