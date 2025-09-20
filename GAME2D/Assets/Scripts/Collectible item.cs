using UnityEngine;

public class Collectibleitem : MonoBehaviour
{
    public enum ItemType { Apple,Banana }

    public ItemType type=ItemType.Apple;
    public int itemValue=1;

    public AudioClip appleSound;
    public AudioClip bananaSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        
            switch (type)
            {
                case ItemType.Apple:
                    GameManager.Instance.TotalApple(itemValue);
                    AudioSource.PlayClipAtPoint(appleSound, transform.position); break;

                case ItemType.Banana:
                    GameManager.Instance.TotalBanana(itemValue);
                    AudioSource.PlayClipAtPoint(bananaSound, transform.position); break;

            }
        Destroy(gameObject);
        
    }
}
