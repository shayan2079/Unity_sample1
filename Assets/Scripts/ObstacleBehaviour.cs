using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] float startRoad = 0f;
    
    GameObject player;
    MenuHandler menuHandler;

    bool isCounted;

    void OnEnable()
    {
        isCounted = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        menuHandler = canvas.GetComponent<MenuHandler>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startRoad)
        {
            this.gameObject.SetActive(false);
        }

        float frontOfObstacle = transform.position.z + transform.localScale.z / 2f;
        float backOfPlayer = player.transform.position.z - player.transform.localScale.z / 2f;

        if (!isCounted && frontOfObstacle < backOfPlayer)
        {
            isCounted = true;
            menuHandler.AddScore();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        menuHandler.DisplayEndGameMenu();
    }
}
