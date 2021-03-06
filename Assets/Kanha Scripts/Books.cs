using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Books : MonoBehaviour
{
    public string bookName = "Book";
    public int maxBooksInScene;
    public int booksPlayerCanCarryAtOnce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You picked up" + bookName);
            if(GameObject.FindGameObjectsWithTag("Book").Length <= maxBooksInScene - booksPlayerCanCarryAtOnce)
            {
                Debug.Log("You cant carry more books then " + booksPlayerCanCarryAtOnce);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
