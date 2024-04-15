using UnityEngine;

public class Box : PassiveItem
{
    public int Health = 2;
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private GameObject _breakEffectPrefab;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        SetHealth(Health);
    }

    public override void OnAffect()
    {
        base.OnAffect();
        Health -= 1;
        Instantiate(_breakEffectPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        _animator.SetTrigger("Shake");
        if (Health < 0)
        {
            Die();
        }
        else
        {
            SetHealth(Health);
        }
    }

    private void SetHealth(int health)
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].SetActive(i <= health);
        }
    }

    [ContextMenu("Die")]
    private void Die()
    {
        Destroy(gameObject);
        ScoreManager.Instance.AddScore(ItemType, transform.position);
    }

}
