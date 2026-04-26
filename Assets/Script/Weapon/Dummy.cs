using UnityEngine;

public class Dummy : MonoBehaviour , ITakeDamage
{
    public void TakeDamage(Data_Stats damage)
    {
        Debug.Log("Take Damage");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
