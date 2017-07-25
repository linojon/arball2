using UnityEngine;
using UnityEngine.Events;

public class BallGame : MonoBehaviour {
    public ThrowControl BallThrowControl;
    public GameObject CourtGameObject;
    public CollisionBehavior GoalCollisionBehavior;

    public UnityEvent OnGoalWon;
    public UnityEvent OnGoalLost;

    private bool wonGoal;

    void Start() {
        BallThrowControl.OnReset.AddListener(OnBallReset);
        GoalCollisionBehavior.OnHitGameObject.AddListener(CheckGoal);
    }

    public void Activate() {
        BallThrowControl.gameObject.SetActive(true);
        CourtGameObject.SetActive(true);
        GoalCollisionBehavior.gameObject.SetActive(true);
    }

    public void Deactivate() {
        BallThrowControl.gameObject.SetActive(false);
        CourtGameObject.SetActive(false);
        GoalCollisionBehavior.gameObject.SetActive(false);
    }

    void OnBallReset() {
        if (wonGoal) {
            OnGoalWon.Invoke();
        } else {
            OnGoalLost.Invoke();
        }
        //Resets the game
        GoalCollisionBehavior.ResetCollision();
        wonGoal = false;
    }

    void CheckGoal(GameObject hitGameObject) {
        print("CheckGoal: ball " + BallThrowControl.gameObject + "  hit " + hitGameObject);

        if (hitGameObject == BallThrowControl.gameObject) {
            print("HIT");
            wonGoal = true;
        }
    }
}
