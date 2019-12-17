using UnityEngine;

public class BackGround : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.backGround = gameObject;
        gameManager.ChoseSeason();
    }
}
