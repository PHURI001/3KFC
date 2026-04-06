using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1.0f;

    public void Init(float _speed)
    {
        speed = _speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Bullet -> " + name + "has no damageDealer");
    }
}
