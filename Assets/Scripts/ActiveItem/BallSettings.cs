using UnityEngine;

[CreateAssetMenu]
public class BallSettings : ScriptableObject
{
    [SerializeField] public Material[] BallMaterials;
    [SerializeField] public Material[] BallProjectionMaterials;
}
