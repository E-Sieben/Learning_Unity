using UnityEngine;

namespace Player
{
    /// <summary>
    ///     Manages Animations for a Player Object
    /// </summary>
    public class AnimationService
    {
        /// <summary>Constant Path to Walking Animation</summary>
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        /// <summary>Defines the Animator to use for Animations</summary>
        private readonly Animator _animator;

        /// <summary>
        ///     Used to initialize an <c>AnimationService</c> that handles Animations for a Player Object
        /// </summary>
        /// <param name="animator"></param>
        public AnimationService(Animator animator)
        {
            _animator = animator;
        }

        /// <summary>Starts the <c>Walk</c> animation</summary>
        public void Walk()
        {
            _animator.SetBool(IsWalking, true);
        }

        /// <summary>Starts the <c>Idle</c> animation</summary>
        public void Idle()
        {
            _animator.SetBool(IsWalking, false);
        }
    }
}