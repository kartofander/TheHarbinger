using UnityEngine;

public class DirectionHint : MonoBehaviour
{
    private const float rotationRadius = 0.5f;
    private const float rotationSpeed = 6f;

    public Transform playerTransform;

    private readonly Vector3 defaultVector = new Vector3(0, rotationRadius, 0);

    void Start()
    {
        transform.localPosition = defaultVector;
    }

    void Update()
    {
        var target = GetNearestObjective();

        if (target.HasValue == false)
        {
            gameObject.SetActive(false);
            return;
        }


        var direction = (target.Value - playerTransform.position).normalized;
        var angle = -(Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg) + 45f;
        var rotation = Quaternion.Euler(0, 0, angle);

        //rotate over time
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        transform.localPosition = Vector3.RotateTowards(transform.localPosition, direction, rotationSpeed * Time.deltaTime, 0.0f);
    }

    private Vector3? GetNearestObjective()
    {
        var objectives = FindObjectsOfType<Objective>();
        
        var nearestDistance = float.MaxValue;
        Vector3? nearestObjective = null;

        foreach (var objective in objectives)
        {
            if (objective.IsActive() == false) continue;

            var distance = Vector3.Distance(objective.transform.position, playerTransform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestObjective = objective.transform.position;
            }
        }

        return nearestObjective;
    }
}
