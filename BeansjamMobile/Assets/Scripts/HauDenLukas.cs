using UnityEngine;

public class HauDenLukas : MonoBehaviour, IAttraction{

    public float scaleBoost = 1.2f;
    [SerializeField] private Scaler scaler;
    [SerializeField] private Scaler redScaler;
    [SerializeField] private SphereCollider jamCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource audioSource;

    // max scale of the red balken
    private float maxScale = 36f;

    public AudioClip hammerSound;
    public AudioClip stopBarSound;

    public void Execute()
    {
        if(redScaler.IsExecutable() && scaler.IsExecutable())
        {
            redScaler.Execute();
            audioSource.PlayOneShot(hammerSound);
        }
        else
        {
            if (scaler.IsExecutable())
            {
                audioSource.PlayOneShot(stopBarSound);
                jamCollider.enabled = true;
                spriteRenderer.enabled = true;
                jamCollider.transform.localScale = Vector3.one;
                int perk = (int)(redScaler.GetCurrentValue() / maxScale * 3f) + 1;
                // TODO Play perk sounds 1-bad, 2-okay, 3-awesome!
                float scale = perk * scaleBoost;
                scaler.Execute(scale);
                redScaler.Stop();
            }
        }
    }
}
