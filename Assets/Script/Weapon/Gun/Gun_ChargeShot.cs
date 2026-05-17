using UnityEngine;

public class Gun_ChargeShot : Abstract_Gun
{
    [SerializeField] private SO_ChargeShot data;
    private float currentCharge;
    private float fireTimer;

    protected override void Update()
    {
        if (isFiring)
        {
            Charge();
            Shoot();
        }
        else
        {
            ResetCharge();
        }
    }
    private void Charge()
    {
        currentCharge += data.chargeSpeed * Time.deltaTime;
        currentCharge = Mathf.Clamp(currentCharge, 0, data.maxCharge);
    }

    public override void Shoot()
    {
        float t = currentCharge / data.maxCharge;

        float currentFireRate = Mathf.Lerp(data.minFireRate, data.maxFireRate, t);

        fireTimer += Time.deltaTime;

        if (fireTimer >= currentFireRate)
        {
            fireTimer = 0;
            SpawnBullet(Bullet, this.transform.position, transform.forward, data.Speed);
        }
    }
    private void ResetCharge()
    {
        currentCharge = 0;
        fireTimer = 0;
    }
}
