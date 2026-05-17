using UnityEngine;

public class Enemy_PopUpTracker : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private void OnEnable()
    {
        enemy.OnTakeDamage += DoDamagePopUp;
        enemy.OnCoinDrop += DoCoinPopUp;
    }

    private void OnDisable()
    {
        enemy.OnTakeDamage -= DoDamagePopUp;
        enemy.OnCoinDrop -= DoCoinPopUp;
    }

    private void DoDamagePopUp(int damage,bool isCri)
    {
        if (isCri)
        {
            UIManager.Instance?.SetPopUptext(transform.position, "CRITICAL: " + damage, Color.red);
        }
        else
        {
            UIManager.Instance?.SetPopUptext(transform.position, damage.ToString(), Color.red);
        }
    }

    private void DoCoinPopUp(int amount)
    {
        UIManager.Instance?.SetPopUptext(transform.position, "+" + amount + " Coin", Color.green);
    }
}
