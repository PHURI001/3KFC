using System;
using UnityEngine;

public class Dummy : MonoBehaviour , ITakeDamage
{
    public event Action OnDeath;
    [SerializeField] private string takeDamageAnimation;
    [SerializeField] private MaterialValueLearp materialValue;
    [SerializeField] private MaterialBlink materialBlink;
    [SerializeField] private ParticleSystem deathVFX;
    [SerializeField] private Rigidbody body;
    [SerializeField] private int Health = 300;

    private Animator animator;
    private bool isDeath = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(Data_Stats damageInfo)
    {
        Health -= damageInfo.damage;
        if (Health < 0 && isDeath == false)
        {
            isDeath = true;
            OnDeath?.Invoke();
            materialValue?.Play();
            deathVFX?.Play();
            Transform playerPos = GameObject.FindAnyObjectByType<Player>().transform;
            body.freezeRotation = false;
            Vector3 knockback = (playerPos.position - body.position).normalized;
            body.AddForce(-knockback * 500);
        }
        else
        {
            materialBlink?.Play();
            Transform playerPos = GameObject.FindAnyObjectByType<Player>().transform;
            Vector3 knockback = (playerPos.position - body.position).normalized;
            body.AddForce(-knockback * 50);
            animator.Play(takeDamageAnimation);
        }
    }
}
