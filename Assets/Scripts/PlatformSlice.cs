using UnityEngine;

public class PlatformSlice : MonoBehaviour
{
    public SliceType sliceType;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MeshCollider _collider;
    [SerializeField] private Material _dead;
    public GameObject hurdle;
    public GameObject boost;

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
            float rng = Random.value;
            if(rng>0.95)
            {
                hurdle.gameObject.SetActive(true);
            }
            else if(rng<0.02)
            {
                boost.gameObject.SetActive(true);
            }
            
        }
    }
}