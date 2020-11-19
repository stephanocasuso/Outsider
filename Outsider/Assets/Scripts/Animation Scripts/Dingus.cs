using UnityEngine;
using UnityEditor;
using System.Collections;

namespace EightDirectionalSpriteSystem
{
    [ExecuteInEditMode]
    public class Dingus : MonoBehaviour
    {

        public ActorBillboard actorBillboard;

        public ActorAnimation idleAnim;
        public ActorAnimation moveAnim;

        private Transform myTransform;
        private ActorAnimation currentAnimation = null;
        private bool fool = false;

        void Awake()
        {
            myTransform = GetComponent<Transform>();
        }

        void Start()
        {
            currentAnimation = idleAnim;
            actorBillboard.PlayAnimation(currentAnimation);
        }

        private void OnEnable()
        {
            currentAnimation = idleAnim;
            actorBillboard.PlayAnimation(currentAnimation);
        }

        private void OnValidate()
        {
            currentAnimation = idleAnim;
            actorBillboard.PlayAnimation(currentAnimation);
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
                if(currentAnimation!=moveAnim){
                    currentAnimation = moveAnim;
                    actorBillboard.PlayAnimation(currentAnimation);
                }
            }
            else{
                if(currentAnimation!=idleAnim){
                    currentAnimation = idleAnim;
                    actorBillboard.PlayAnimation(currentAnimation);
                }
            }

        }
    }
}
