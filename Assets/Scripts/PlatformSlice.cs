using UnityEngine;

public class PlatformSlice : MonoBehaviour
{
    public SliceType sliceType;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MeshCollider _collider;
    [SerializeField] private Material _dead;
    public GameObject hurdle;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<MeshCollider>();
    }

    public void Init(SliceType type)
    {
        sliceType = type;
        if (type == SliceType.Empty)
        {
            _meshRenderer.enabled = false;
            _collider.enabled = false;
        }else if (type == SliceType.Deadly)
        {
            _meshRenderer.material = _dead;
        }
        else if(type == SliceType.Normal)
        {
            if(Random.value>0.9)
            {
                hurdle.gameObject.SetActive(true);
            }
        }
    }
}