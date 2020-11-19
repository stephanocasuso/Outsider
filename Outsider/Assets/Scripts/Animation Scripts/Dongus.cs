using UnityEngine;
using UnityEditor;
using System.Collections;

namespace EightDirectionalSpriteSystem
{
    [ExecuteInEditMode]
    public class Dongus : MonoBehaviour
    {

        public ActorBillboard actorBillboard;

        public ActorAnimation idleAnim;

        private Transform myTransform;
        private ActorAnimation currentAnimation = null;

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
 
        }
    }
}
