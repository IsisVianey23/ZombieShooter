using UnityEngine;

public class Player : MonoBehaviour
{
    private Health health;
    private UIController uiController;

    private bool isPlaying = true;

    private GameObject _key;
    private void Start()
    {
        health = GetComponent<Health>();
        uiController = GetComponent<UIController>();
        SoundManager.instance.Play("zelda");
    }

    private void OllisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isPlaying)
        {
            health.TakeDamage(1);
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            transform.position += pushDirection * 0.5f;
        }
       /* else if (collision.gameObject.CompareTag("Key"))
        //{
          //  isPlaying = false;
           // uiController.ShowYouWinUI(true);
        }*/      
    }

    public void Die()
    {
        uiController.ShowGameOverUI(true);
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Key")&& _key == null)
        {
            GrabKey(other.transform);
        }
    }
    private void GrabKey(Transform key)
    {
        _key = key.gameObject;
        gameObject.GetComponent<UIController>().ShowYouWinUI(true);
        Destroy(_key);
    }

}
