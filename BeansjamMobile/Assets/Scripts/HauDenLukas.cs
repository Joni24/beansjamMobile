using UnityEngine;

public class HauDenLukas : MonoBehaviour, IAttraction{

    private float cooldown = 1f;
    [SerializeField] private Scaler scaler;
    [SerializeField] private SphereCollider jamCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Execute()
    {
        if(scaler.IsExecutable())
        {
            jamCollider.enabled = true;
            spriteRenderer.enabled = true;
            jamCollider.transform.localScale = Vector3.one;
            scaler.Execute(Random.Range(1f, 2f));
        }
    }
}
