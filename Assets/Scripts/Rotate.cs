using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 5;
   

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);
    }
}