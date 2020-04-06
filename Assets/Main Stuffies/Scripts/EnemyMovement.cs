using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem goalfx;
	[SerializeField] float moveSpeed = 50f;
	private Transform toGoTo;
	
	void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

	void Update()
	{
		Move();
	}

	//runs every frame for smooth movement (could put in Update but if I needed to expand script/ add more functions to the update I would have to do this anyways)
	void Move()
	{

		float MovementSpeed = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, toGoTo.position, MovementSpeed);
	}


	IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
			toGoTo = waypoint.transform;
			toGoTo = toGoTo.transform;
			yield return new WaitUntil(() => isAtPosition(waypoint) == true);
		}
        GetComponent<Enemy>().KillEnemy();
    }

	bool isAtPosition(Waypoint wp)
	{
		if (this.transform.position == wp.transform.position)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void setSpeed(float speed)
	{
		moveSpeed = speed;
	}
}



