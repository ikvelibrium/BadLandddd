using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform _beginLvl;
    public Transform _endLvl;
    [SerializeField] private List<Transform> _Traps = new List<Transform>();

    private void Start()
    {
        int picker = 0;
        for (int i = 0; i < _Traps.Count; i++)
        {
            picker = Random.Range(0, _Traps.Count);
            _Traps[picker].gameObject.SetActive(true);
        }
    }

}
