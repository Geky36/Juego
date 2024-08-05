using UnityEngine;

public class EspadaAtaque : MonoBehaviour
{
    private BoxCollider2D espada;

    private void Awake()
    {
        espada = GetComponent<BoxCollider2D>();
    }

    private void Atacar (Collider2D collision)
    {
        if (collision.CompareTag("Enemigo")){
            Destroy(collision.gameObject);
        }
    }
}
