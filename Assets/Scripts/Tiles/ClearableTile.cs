using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearableTile : MonoBehaviour
{
    public AnimationClip clearAnimation; 

    private bool isCleared = false;

    protected Tile tile;

    public bool IsCleared
    {
        get { return isCleared; }
    }

    private void Awake()
    {
        tile = GetComponent<Tile>();
    }

    public virtual void Clear()
    {
        tile.BoardRef.level.OnTileClear(tile);
        isCleared = true;
        StartCoroutine(ClearCoroutine());
    }

    private IEnumerator ClearCoroutine()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.Play(clearAnimation.name.ToString());
            yield return new WaitForSeconds(clearAnimation.length);

            Destroy(gameObject);
        }
    }
}
