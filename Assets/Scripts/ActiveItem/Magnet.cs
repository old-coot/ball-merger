using System.Collections;
using UnityEngine;

public class Magnet : ActiveItem
{
    [Header("Magnet")]
    [SerializeField] private float _affectRadius = 1.5f;
    [SerializeField] private float _forceValue = 1000f;

    [SerializeField] private GameObject _affectArea;
    [SerializeField] private GameObject _effectPrefab;

    protected override void Start()
    {
        base.Start();
        _affectArea.SetActive(false);
    }

    [ContextMenu("AffectProcess")]
    private IEnumerator AffectProcess()
    {
        _affectArea.SetActive(true);
        _animator.enabled = true;
        float elapsedTime = 0f;

        while (elapsedTime < 2f) // ���������� �� ���������� 2 ������
        {
            elapsedTime += Time.deltaTime;

            Collider[] colliders = Physics.OverlapSphere(transform.position, _affectRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody rigidbody = colliders[i].attachedRigidbody;
                if (rigidbody)
                {
                    Vector3 fromTo = (transform.position - rigidbody.transform.position).normalized;
                    float currentForce = Mathf.Lerp(0, _forceValue, elapsedTime / 2f);
                    rigidbody.AddForce(fromTo * currentForce);
                }
            }
            yield return null;
        }


        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        _affectArea.transform.localScale = Vector3.one * _affectRadius * 2f;
    }

    public override void DoEffect()
    {
        base.DoEffect();
        StartCoroutine(AffectProcess());
    }
}
