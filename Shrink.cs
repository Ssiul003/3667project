using System.Collections;
using UnityEngine;

public class Shrink: MonoBehaviour
{
    public float shrinkDuration = 5.0f; 
    public float minScale = 0.1f;       
    public float respawnDelay = 3.0f;   
    private Vector3 originalScale;     

    private void Start()
    {
        
        originalScale = transform.localScale;

        
        StartCoroutine(ShrinkAndDisappear());
    }

   
    private IEnumerator ShrinkAndDisappear()
    {
        float elapsedTime = 0f;

        
        while (elapsedTime < shrinkDuration)
        {
           
            float scale = Mathf.Lerp(1f, minScale, elapsedTime / shrinkDuration);
            transform.localScale = originalScale * scale;

            
            elapsedTime += Time.deltaTime;

            yield return null; 
        }

        
        gameObject.SetActive(false);

        
        yield return new WaitForSeconds(respawnDelay);

       
        transform.localScale = originalScale;

        
        gameObject.SetActive(true);

        
        StartCoroutine(ShrinkAndDisappear());
    }
}
