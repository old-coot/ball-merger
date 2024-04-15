using UnityEngine;

public class Stone : PassiveItem
{
    [SerializeField] private GameObject _dieEffect;
    [SerializeField] private int _level = 2;
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private Stone _stonePrefab;


    [ContextMenu("Die")]
    public override void OnAffect()
    {
        base.OnAffect();
        if (_level > 0)
        {
            for (int i = 0; i < 2; i++)
            {
                CreateChildRock(_level - 1);
            }
        }
        else
        {
            ScoreManager.Instance.AddScore(ItemType, transform.position);
        }
        Die();
    }

    void CreateChildRock(int level)
    {
        Stone newStone = Instantiate(_stonePrefab, transform.position, Quaternion.identity);
        newStone.SetLevel(level);
    }

    public void SetLevel(int level)
    {
        _level = level;
        float scale = 1;
        if (level == 2)
        {
            scale = 1f;
        }
        else if (level == 1)
        {
            scale = .7f;
        }
        else if (level == 0)
        {
            scale = .45f;
        }

        _visualTransform.localScale = Vector3.one * scale;
    }

    void Die()
    {
        Instantiate(_dieEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
