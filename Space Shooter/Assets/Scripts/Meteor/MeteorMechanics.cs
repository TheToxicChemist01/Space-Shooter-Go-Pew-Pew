using UnityEngine;

public class MeteorMechanics : MonoBehaviour
{
    //Spawner spawnMeteors;

    [SerializeField]
    private float timeRemaining = 10f;
    private float previousTimeRemaining;
   
    public GameObject meteorGameObject;
    public Vector3 meteorPosition;
    public Quaternion meteorRotation;

   
    public bool timerRunning;

    private void Awake()
    {
        previousTimeRemaining = timeRemaining;
        //spawnMeteors = gameObject.AddComponent<Spawner>();
    }

    // Start is called before the first frame update
    void Update()
    {
        var meteorsAlive = GameObject.FindGameObjectsWithTag("Meteor");
        if (meteorsAlive.Length <= 0 && timerRunning == false)
        {
            timeRemaining = previousTimeRemaining + 1f;
            previousTimeRemaining = timeRemaining;

            timerRunning = true;
        }

        if (timerRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if (timeRemaining <= 0)
            {
                timeRemaining = 0;

                System.Random randomXPosition = new System.Random();
                int randomX = randomXPosition.Next(-10, 6);
                meteorPosition = new Vector3(randomX, 6, 0);
                var meteor = Instantiate(meteorGameObject, meteorPosition, meteorRotation);

                timerRunning = false;
            }
        }



    }


}
