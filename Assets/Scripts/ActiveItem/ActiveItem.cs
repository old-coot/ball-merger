using TMPro;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    public int Level;
    public float Radius;
    [SerializeField] protected TextMeshProUGUI _levelText;

    [SerializeField] private SphereCollider _collider;
    [SerializeField] private SphereCollider _trigger;

    public Rigidbody Rigidbody;
    public bool IsDead;
    public Projection Projection;

    [SerializeField] private Animator _animator;

    [ContextMenu("IncreaseLavel")]

    private void Start()
    {
        Projection.Hide();
    }
    public void IncreaseLevel()
    {
        Level++;
        SetLevel(Level);

        _animator.SetTrigger("IncreaseLavel");

        _trigger.enabled = false;
        Invoke(nameof(EnableTrigger), 0.08f);
    }
    public virtual void SetLevel(int level)
    {
        Level = level;
        int number = (int)Mathf.Pow(2, level + 1);
        string numberString = number.ToString();
        _levelText.text = numberString;



    }

    private void EnableTrigger()
    {
        _trigger.enabled = true;
    }


    public void SetupToTube()
    {
        _trigger.enabled = false;
        _collider.enabled = false;
        Rigidbody.isKinematic = true;
        Rigidbody.interpolation = RigidbodyInterpolation.None;
    }

    public void Drop()
    {
        _trigger.enabled = true;
        _collider.enabled = true;
        Rigidbody.isKinematic = false;
        Rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        transform.parent = null;
        Rigidbody.velocity = Vector3.down * 0.8f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsDead) return;

        if (other.attachedRigidbody)
        {
            ActiveItem otherItem = other.attachedRigidbody.GetComponent<ActiveItem>();
            if (otherItem)
            {
                if (!otherItem.IsDead && Level == otherItem.Level)
                {
                    CollapseManager.Instance.Collapse(this, otherItem);
                }
            }
        }
    }

    public void Disable()
    {
        _trigger.enabled = false;
        _collider.enabled = false;
        Rigidbody.isKinematic = true;
        IsDead = true;
    }

    internal void Die()
    {
        Destroy(gameObject);
    }
}
