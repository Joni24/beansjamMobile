using UnityEngine;

public class HauDenLukas : MonoBehaviour, IAttraction{

    private float cooldown = 1f;
    [SerializeField] private Scaler scaler;



    public void Execute()
    {
        scaler.Execute();
    }
}
