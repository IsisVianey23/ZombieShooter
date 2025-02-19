using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string enemyToLook = "Player";

    [SerializeField]
    private float speed = 1f;

    private Transform objetive;
    private  Health health;

    [SerializeField]
    private int damage = 1;


    private void Start()
    {
        objetive = GameObject.FindGameObjectWithTag(enemyToLook).transform; //obtiene la posición del player u objetivo
        health = GetComponent<Health>(); //el enemigo recibe daño
    }

private void Update()
    {
        FollowObjetive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health.TakeDamage(collision.gameObject.GetComponent<Bullet>().Damage);
            Destroy(collision.gameObject);
        }
         if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void FollowObjetive()
    {
        Vector3 direction = (objetive.position - transform.position).normalized;
        if (direction.magnitude > 0.1f)
        {
         transform.position += direction * speed * Time.deltaTime;
         //transform.rotation = Quaternion.LookRotation(direction);
         Quaternion lookRotation = Quaternion.LookRotation(direction);
         transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        SoundManager.instance.Play("enemydie");
    }
    
}
